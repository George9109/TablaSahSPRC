using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TablaSahSPRC
{
    public class ConexiuneServer
    {
        private TcpClient client;
        private NetworkStream stream;

        // ==========================================
        // EVENIMENTE (Cum anunțăm interfața grafică)
        // ==========================================
        public event Action<string> OnWaiting;
        public event Action<string> OnOpponentDisconnected;
        public event Action<string> OnTablaUpdate;

        // Evenimentele noi pentru Chat (Așteaptă un singur string care conține "Nume: Mesaj")
        public event Action<string> OnChatPrivateReceived;
        public event Action<string> OnChatGlobalReceived;

        public async Task<bool> Conecteaza(string ip, int port)
        {
            try
            {
                client = new TcpClient();
                await client.ConnectAsync(ip, port);
                stream = client.GetStream();

                _ = AscultaMesaje();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // ==========================================
        // FUNCȚII DE TRIMIS CĂTRE SERVER
        // ==========================================

        private async Task TrimiteText(string mesaj)
        {
            if (stream != null && client.Connected)
            {
                // Adăugăm \n pentru a delimita clar pachetele pe rețea
                byte[] dataToSend = Encoding.UTF8.GetBytes(mesaj + "\n");
                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);
                await stream.FlushAsync(); // Forțăm golirea buffer-ului (evită întârzierile)
            }
        }

        // Am adăugat "_ =" pentru a scăpa de avertizările (Warnings) din Visual Studio
        public void TrimiteCreate(string lobbyCode) { _ = TrimiteText($"CREATE|{lobbyCode}"); }
        public void TrimiteJoin(string lobbyCode) { _ = TrimiteText($"JOIN|{lobbyCode}"); }
        public void TrimiteStart(string lobbyCode) { _ = TrimiteText($"START|{lobbyCode}"); }
        public void TrimiteClose() { _ = TrimiteText("CLOSE"); }
        public void TrimiteSpectate(string lobbyCode) { _ = TrimiteText($"SPECTATE|{lobbyCode}"); }
        public void TrimiteUpdate(string lobbyCode, string vectorTabla) { _ = TrimiteText($"UPDATE|{lobbyCode}|{vectorTabla}"); }

        // Funcțiile de chat
        public void TrimiteChat(string lobbyCode, string nume, string mesaj) { _ = TrimiteText($"CHAT|{lobbyCode}|{nume}|{mesaj}"); }
        public void TrimiteChatPrivate(string lobbyCode, string nume, string mesaj) { _ = TrimiteText($"CHAT_PRIVATE|{lobbyCode}|{nume}|{mesaj}"); }

        // ==========================================
        // FUNCȚII DE PRIMIT DE LA SERVER
        // ==========================================

        private async Task AscultaMesaje()
        {
            byte[] buffer = new byte[4096];
            try
            {
                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Conexiune închisă de server

                    string mesajPrimit = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Procesăm mesajul curățat de spații în plus
                    ProceseazaMesaj(mesajPrimit.Trim());
                }
            }
            catch (Exception)
            {
                // Deconectat sau eroare rețea
            }
        }

        private void ProceseazaMesaj(string mesajComplet)
        {
            string[] parti = mesajComplet.Split('|');
            string comanda = parti[0];

            switch (comanda)
            {
                case "WAITING":
                    if (parti.Length > 1) OnWaiting?.Invoke(parti[1]);
                    break;

                case "OPPONENT_DISCONNECTED":
                    if (parti.Length > 1) OnOpponentDisconnected?.Invoke(parti[1]);
                    break;

                case "UPDATE_SUCCESS":
                    // parti[1] va conține string-ul cu starea tablei
                    if (parti.Length > 1) OnTablaUpdate?.Invoke(parti[1]);
                    break;

                // Cazul pentru Chat-ul Online (Global)
                case "CHAT_GLOBAL":
                case "CHAT_MSG": // În caz că serverul folosește vechiul nume
                    if (parti.Length > 1)
                    {
                        // Unim înapoi absolut toate bucățile trimise de server, 
                        // în caz că mesajul conține la rândul lui alte caractere '|'
                        string mesajAdevărat = string.Join(" ", parti, 1, parti.Length - 1);
                        OnChatGlobalReceived?.Invoke(mesajAdevărat);
                    }
                    break;

                // Cazul pentru Chat-ul Privat
                case "CHAT_PRIVATE_MESSAGE":
                    if (parti.Length > 1)
                    {
                        // Unim înapoi absolut toate bucățile trimise de server
                        string mesajAdevărat = string.Join(" ", parti, 1, parti.Length - 1);
                        OnChatPrivateReceived?.Invoke(mesajAdevărat);
                    }
                    break;
            }
        }
    }
}