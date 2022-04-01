using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using WebSocketSharp;
//using WebSocketSharp.Server;

namespace StarSharksTool
{

    //public class Laputa : WebSocketBehavior
    //{
    //    protected override void OnMessage(MessageEventArgs e)
    //    {
    //        var s = int.TryParse(e.Data, out int val);
    //        if (s == true)
    //        {
    //            Services.Service.RentedSharkIds.Add(val);
    //        }
    //    }
    //}
    //public class GasUsage : WebSocketBehavior
    //{
    //    protected override void OnMessage(MessageEventArgs e)
    //    {
    //        var res = JsonConvert.DeserializeObject<Dictionary<int, decimal>>(e.Data);
    //        Global.DynamicGASPrice = res;
    //    }
    //}
    public partial class BlackListListenerForm : Form
    {
        //static IPAddress ipAd = IPAddress.Parse("127.0.0.1");
        //static int PortNumber = 8888;
        //WebSocketServer wssv;
        //public BlackListListenerForm()
        //{
        //    InitializeComponent();
        //}

        //private void BlackListListenerForm_Load(object sender, EventArgs e)
        //{
        //    Thread ThreadingServer = new Thread(StartServer);
        //    ThreadingServer.Start();
        //}

        //private void THREAD_MOD(string teste)
        //{
        //    txtStatus.Text += Environment.NewLine + teste;
        //}

        //private void StartServer()
        //{
        //    wssv = new WebSocketServer(ipAd, PortNumber);

        //    wssv.AddWebSocketService<Laputa>("/BlackIdReport");
        //    wssv.AddWebSocketService<GasUsage>("/GasUsage");
        //    wssv.Start();
        //}

        //private void BlackListListenerForm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    wssv.Stop();
        //}
    }
}
