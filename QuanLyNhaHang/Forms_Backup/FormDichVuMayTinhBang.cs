using DbMapping;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Win32;
using Newtonsoft.Json;
using No1Lib.Db;
using No1Lib.Sys;
using No1Lib.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System;

namespace QuanLyNhaHang
{
    /// <summary>
    /// Form: Dịch vụ máy tính bảng (ID: 12b301d8-7cc8-40d4-aaaa-c8f07511c407)
    /// </summary>
    public partial class FormDichvumaytinhbang : Form
    {
        public string SFormId { get; } = "12b301d8-7cc8-40d4-aaaa-c8f07511c407";
        public string SFormTitle { get; } = "Dịch vụ máy tính bảng";

        public FormDichvumaytinhbang()
        {
            InitializeComponent();
        }


                private void ReturnOk(object obj)
                    ReturnObject item = new ReturnObject(obj);
                    writeSuccess();
                    outputStream.Write(Newtonsoft.Json.JsonConvert.SerializeObject(item));

                private void ReturnError(string message)
                    writeSuccess();
                    ReturnObject item = new ReturnObject(null);
                    item.message = message;
                    outputStream.Write(Newtonsoft.Json.JsonConvert.SerializeObject(item));

                private Database GetDb()
                    Database db = Config.Db.Copy();
                    return db;

                private void ProcessData(bool waitToExit)
                    //write to xml file
                    string dir = Application.StartupPath + "\\temp\\";
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    string xmlFile = Guid.NewGuid().ToString().Replace("-", "");

                    using (StreamWriter stream = new StreamWriter(dir + xmlFile, false, Encoding.UTF8))
                        dt.WriteXml(stream);
                        stream.Flush();
                        stream.Close();


                    //start external processor
                    string exePath = Application.StartupPath + "\\PrintProcessor.exe";

                    ProcessStartInfo info = new ProcessStartInfo(exePath, xmlFile);
                    //info.WindowStyle = ProcessWindowStyle.Hidden;
                    //info.CreateNoWindow = true;
                    Process p = new Process();
                    p.StartInfo = info;
                    p.Start();
                    //return back to client
                    if (waitToExit)
                        p.WaitForExit(2 * 60 * 1000);
                        Thread.Sleep(20);

                        outputStream.Write(File.ReadAllText(dir + xmlFile + "_out"));
                        outputStream.Flush();

                        try
                            //remove temp file
                            File.Delete(dir + xmlFile);
                            File.Delete(dir + xmlFile + "_out");
                        catch
                    else
                        outputStream.Write("ok");
                        outputStream.Flush();

                    /*
                    PrintProcessor.Program.Main(new string[] { xmlFile });
                    outputStream.Write(File.ReadAllText(dir + xmlFile + "_out"));
                    outputStream.Flush();
                    */


                private const int BUF_SIZE = 4096;
                public void handlePOSTRequest()
                    int content_len = 0;
                    MemoryStream ms = new MemoryStream();

                    DataRow[] rows = dt.Select("NAME ='Content-Length'");
                    if (rows.Length > 0)
                        content_len = Convert.ToInt32(rows[0]["VALUE"]);
                        if (content_len > MAX_POST_SIZE)
                            throw new Exception(
                                String.Format("POST Content-Length({0}) too big for this simple server",
                                content_len));
                        byte[] buf = new byte[BUF_SIZE];
                        int to_read = content_len;
                        while (to_read > 0)
                            int numread = this.inputStream.Read(buf, 0, Math.Min(BUF_SIZE, to_read));
                            if (numread == 0)
                                if (to_read == 0)
                                    break;
                                else
                                    throw new Exception("client disconnected during post");
                            to_read -= numread;
                            ms.Write(buf, 0, numread);
                        ms.Seek(0, SeekOrigin.Begin);

                    string data = new StreamReader(ms).ReadToEnd();
                    AddItemData("POST", data, DataType.POST);
                    ProcessData(true);

                public void writeSuccess(string content_type, params string[] customHeader)
                    if (content_type == null) content_type = "text/html;charset=UTF-8";
                    outputStream.WriteLine("HTTP/1.0 200 OK");
                    outputStream.WriteLine("Content-Type: " + content_type);
                    outputStream.WriteLine("Connection: close");
                    if (customHeader.Length > 0)
                        foreach (string s in customHeader)
                            if (s.Length > 0)
                                outputStream.WriteLine(s);
                    outputStream.WriteLine("");

                public void writeSuccess(string content_type)
                    writeSuccess(content_type, "");

                public void writeSuccess()
                    writeSuccess("text/html;charset=UTF-8");

                public void writeSuccessByCookie(string cookie1, string cookie2)
                    outputStream.WriteLine("HTTP/1.0 200 OK");
                    outputStream.WriteLine("Content-Type: text/html;charset=UTF-8");
                    outputStream.WriteLine("Connection: close");
                    outputStream.WriteLine("Set-Cookie: " + cookie1 + ";");
                    outputStream.WriteLine("Set-Cookie: " + cookie2 + ";");
                    outputStream.WriteLine("");

                public void redirect(string location)
                    outputStream.WriteLine("HTTP/1.0 302 Found");
                    outputStream.WriteLine("Location: " + location);
                    outputStream.WriteLine("");

                internal static string Key = "";

                public void writeFailure(string error)
                    try
                        writeSuccess();
                        outputStream.WriteLine(error);
                    catch

            class ReturnObject
                public string status;

                public ReturnObject(object data)
                    this.data = data;
                    this.status = data == null ? "ERROR" : "OK";

                public object data;
                public string message = "";

            class DonHangChiTietObject
                public string ID;
                public string TenHang;
                public int TrangThai;
                public decimal SoLuong;
                public decimal DonGia;
                public int KhachGoi;
                public decimal ThanhTien;
                public string MatHangID;
                public string ThemLuc;

            class BepChiTietObject
                public string ID;
                public string TenHang;
                public decimal SoLuong;
                public string ThemLuc;
                public string TrangThai;
                public string TenPhong;
                public int DaThanhToan;
                public string PhongID;
                public string MatHangID;

            class OkObject
                public string Status
                    get { return "ok"; }
        #endregion
    }
}