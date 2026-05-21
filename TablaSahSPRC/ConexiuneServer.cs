using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TablaSahSPRC
{
    public class ConexiuneServer
    {
        private TcpClient client;
        private NetworkStream stream;

        // EVENIMENTE: Așa anunțăm interfața grafică că am primit ceva de la server
        public event Action<string> OnWaiting;
        public event Action<string> OnOpponentDisconnected;
        public event Action<string, string> OnChatReceived;
        public event Action<string> OnTablaUpdate; // Pentru când primim vectorTabla

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
        // FUNCȚII DE TRIMIS (PRIMITIVELE COLEGULUI)
        // ==========================================

        private async Task TrimiteText(string mesaj)
        {
            if (stream != null && client.Connected)
            {
                byte[] dataToSend = Encoding.UTF8.GetBytes(mesaj);
                await stream.WriteAsync(dataToSend, 0, dataToSend.Length);
            }
        }

        public void TrimiteCreate(string lobbyCode) => TrimiteText($"CREATE|{lobbyCode}");
        public void TrimiteJoin(string lobbyCode) => TrimiteText($"JOIN|{lobbyCode}");
        public void TrimiteStart(string lobbyCode) => TrimiteText($"START|{lobbyCode}");
        public void TrimiteClose() => TrimiteText("CLOSE");
        public void TrimiteSpectate(string lobbyCode) => TrimiteText($"SPECTATE|{lobbyCode}");

        // Aici va trebui să transformăm tablaLogica într-un text (vector) și să o trimitem
        public void TrimiteUpdate(string lobbyCode, string vectorTabla) => TrimiteText($"UPDATE|{lobbyCode}|{vectorTabla}");

        public void TrimiteChat(string lobbyCode, string mesaj) => TrimiteText($"CHAT|{lobbyCode}|{mesaj}");
        public void TrimiteChatPrivate(string lobbyCode, string mesaj) => TrimiteText($"CHAT_PRIVATE|{lobbyCode}|{mesaj}");


        // ==========================================
        // FUNCȚII DE PRIMIT (CE NE RĂSPUNDE SERVERUL)
        // ==========================================

        private async Task AscultaMesaje()
        {
            byte[] buffer = new byte[4096]; // Buffer un pic mai mare pentru vectorTabla
            try
            {
                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Conexiune închisă

                    string mesajPrimit = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Uneori serverul poate trimite mai multe mesaje lipite, le despărțim (dacă va fi cazul)
                    ProceseazaMesaj(mesajPrimit.Trim());
                }
            }
            catch (Exception)
            {
                // Deconectat
            }
        }

        private void ProceseazaMesaj(string mesajComplet)
        {
            // Despărțim textul primit folosind caracterul '|'
            string[] parti = mesajComplet.Split('|');
            string comanda = parti[0];

            switch (comanda)
            {
                case "WAITING":
                    // Ex: WAITING|lobbyCode|
                    if (parti.Length > 1) OnWaiting?.Invoke(parti[1]);
                    break;

                case "OPPONENT_DISCONNECTED":
                    // Ex: OPPONENT_DISCONNECTED|mesaj
                    if (parti.Length > 1) OnOpponentDisconnected?.Invoke(parti[1]);
                    break;

                case "CHAT_MSG":
                case "CHAT_PRIVATE_MESSAGE":
                    // Depinde cum îți trimite colegul restul textului, presupunem că pe poziția 1 e mesajul
                    if (parti.Length > 1) OnChatReceived?.Invoke(comanda, parti[1]);
                    break;

                // Nu a specificat în "primesti", dar sigur serverul va trimite înapoi "UPDATE" celuilalt jucător!
                case "UPDATE":
                    if (parti.Length > 2) OnTablaUpdate?.Invoke(parti[2]); // parti[2] ar fi vectorTabla
                    break;
            }
        }
    }
}