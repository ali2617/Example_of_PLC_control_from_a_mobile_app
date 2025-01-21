using System;
using Microsoft.Maui.Controls;
using NModbus;
using System.Net.Sockets;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnStartButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Modbus TCP bağlantısını başlat
                string plcIpAddress = "192.168.0.1"; // PLC IP adresi
                int plcPort = 502; // Modbus TCP portu

                using (TcpClient client = new TcpClient(plcIpAddress, plcPort))
                {
                    // Modbus TCP Master oluştur
                    var factory = new ModbusFactory();
                    var master = factory.CreateMaster(client);

                    // Slave ID (default olarak 1 kullanılır)
                    byte slaveId = 1;

                    // Coil 0 (%I0.0) adresini TRUE olarak ayarla
                    ushort coilAddress = 0; // Coil adresi (0)
                    master.WriteSingleCoil(slaveId, coilAddress, true);

                    // Başarı mesajı
                    await DisplayAlert("Başarılı", "%I0.0 başarıyla set edildi!", "Tamam");
                }
            }
            catch (Exception ex)
            {
                // Hata mesajı
                await DisplayAlert("Hata", $"PLC'ye bağlanırken hata oluştu: {ex.Message}", "Tamam");
            }
        }
    }
}
