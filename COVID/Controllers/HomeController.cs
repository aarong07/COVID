using COVID.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace COVID.Controllers
{
public class HomeController : Controller
{
    //SqlConnection con = new SqlConnection();
    //SqlCommand com = new SqlCommand();
    //SqlDataReader dr;
    //Monitoreo Sintomas ID=4, Monitoreo Sospechoso ID=5, AutoEvaluacion ID=1, Sospecha ID=2, Positivo=3
    string cn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
    public ActionResult Index(trabajador st)
    {
        Session["Nombre"] = st.Nombre;
        Session["Nomina"] = string.Empty;
        ListaS();
        ListaA();
        ListaP();
        ListaT();
        return View();
    }
    public ActionResult Inicio(trabajador st, string nomina1)
    {
        Session["Nombre"] = st.Nombre;
        ListaS();
        ListaA();
        ListaP();
        ListaT();
        List<trabajador> t = new List<trabajador>();
        SqlConnection sqlconn = new SqlConnection(cn);
        //string sqlquery = "Select t.Nomina, Nombre, IdSitio, IdArea, IdProceso, IdTurno, t.Receta, ComprobanteCOVID, Telefono, ms.Estuveencontacto , ms.dipositivo  from Trabajador t inner join MSintomas ms on t.nomina = ms.nomina where t.Nomina ='"+nomina1+"'";
        string sqlquery = "Select t.Nomina,t.RegresarAlMonitoreo, t.RegresarASospecha, t.RegresarAPositivo,t.Vulnerable ,Nombre, IdSitio, IdArea, IdProceso, IdTurno, t.Receta, ComprobanteCOVID, Telefono " +
        "from Trabajador t  " +
        "where t.Nomina = '" + nomina1 + "'";
        SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
        SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            trabajador tt = new trabajador();
            //tt.ID = dr["ID"].ToString();
            tt.Nomina = dr["Nomina"].ToString();
            tt.Nombre = dr["Nombre"].ToString();
            tt.IdSitio = dr["IdSitio"].ToString();
            tt.IdArea = dr["IdArea"].ToString();
            tt.IdProceso = dr["IdProceso"].ToString();
            tt.IdTurno = dr["IdTurno"].ToString();
            tt.Receta = dr["Receta"].ToString();
            tt.ComprobanteCOVID = dr["ComprobanteCOVID"].ToString();
            tt.Telefono = dr["Telefono"].ToString();
            //tt.Estuveencontacto = int.Parse(dr["Estuveencontacto"].ToString());
            //tt.Dipositivo = int.Parse(dr["Dipositivo"].ToString());
            //tt.MDiario = int.Parse(dr["MDiario"].ToString());
            tt.RegresarAlMonitoreo = int.Parse(dr["RegresarAlMonitoreo"].ToString());
            tt.Vulnerable = int.Parse(dr["Vulnerable"].ToString());
            tt.RegresarASospecha = int.Parse(dr["RegresarASospecha"].ToString());
            tt.RegresarAPositivo = int.Parse(dr["RegresarAPositivo"].ToString());
            t.Add(tt);
            sqlconn.Close();

            ViewData["Nomina"] = tt.Nomina;
            ViewData["Nombre"] = tt.Nombre;
            ViewData["Sitio"] = tt.IdSitio;
            ViewData["Area"] = tt.IdArea;
            ViewData["Proceso"] = tt.IdProceso;
            ViewData["Turno"] = tt.IdTurno;
            ViewData["Telefono"] = tt.Telefono;
            ViewData["Estuvencontacto"] = tt.Estuveencontacto;
            ViewData["Dipositivo"] = tt.Dipositivo;
            ViewData["MDiario"] = tt.MDiario;
            ViewData["Regresar"] = tt.RegresarAlMonitoreo;
            ViewData["RegresarSospecha"] = tt.RegresarASospecha;
            ViewData["RegresarPositivo"] = tt.RegresarAPositivo;
            ViewData["Vulnerable"] = tt.Vulnerable;


            string nombre = (string)ViewData["Nombre"];
            Session["Nombre"] = nombre;

            string nomina = (string)ViewData["Nomina"];
            Session["Nomina"] = nomina;
        }
        if (Session["Nombre"] == null)
        {
            Session["Nomina1"] = nomina1;
            ViewData["Nomina1"] = Session["Nomina1"];
            return View("Inicio2");
        }
        return View(t);
    }
    public List<sitio> ListaSitio()
    {
        SqlConnection db = new SqlConnection(cn);
        string query = "select ID, Descripcion from Sitio";
        SqlCommand cmd = new SqlCommand(query, db);
        db.Open();

        List<sitio> list1 = new List<sitio>();
        using (IDataReader dataReader = cmd.ExecuteReader())
        {
            while (dataReader.Read())
            {
                sitio obj = new sitio();
                if (dataReader["ID"] != DBNull.Value)
                {
                    if (dataReader["ID"] != DBNull.Value) { obj.ID = (dataReader["ID"].ToString()); }
                    if (dataReader["Descripcion"] != DBNull.Value) { obj.Descripcion = (string)dataReader["Descripcion"]; }
                    list1.Add(obj);
                }
            }
            return list1;
        }
    }
    public List<sitio> ListaArea()
    {
        SqlConnection db = new SqlConnection(cn);
        string query = "select ID, Descripcion from Area";
        SqlCommand cmd = new SqlCommand(query, db);
        db.Open();

        List<sitio> list1 = new List<sitio>();
        using (IDataReader dataReader = cmd.ExecuteReader())
        {
            while (dataReader.Read())
            {
                sitio obj = new sitio();
                if (dataReader["ID"] != DBNull.Value)
                {
                    if (dataReader["ID"] != DBNull.Value) { obj.ID = (dataReader["ID"].ToString()); }
                    if (dataReader["Descripcion"] != DBNull.Value) { obj.Descripcion = (string)dataReader["Descripcion"]; }
                    list1.Add(obj);
                }
            }
            return list1;
        }
    }
    public List<sitio> ListaProceso()
    {
        SqlConnection db = new SqlConnection(cn);
        string query = "select ID, Descripcion from Proceso";
        SqlCommand cmd = new SqlCommand(query, db);
        db.Open();

        List<sitio> list1 = new List<sitio>();
        using (IDataReader dataReader = cmd.ExecuteReader())
        {
            while (dataReader.Read())
            {
                sitio obj = new sitio();
                if (dataReader["ID"] != DBNull.Value)
                {
                    if (dataReader["ID"] != DBNull.Value) { obj.ID = (dataReader["ID"].ToString()); }
                    if (dataReader["Descripcion"] != DBNull.Value) { obj.Descripcion = (string)dataReader["Descripcion"]; }
                    list1.Add(obj);
                }
            }
            return list1;
        }
    }
    public List<sitio> ListaTurno()
    {
        SqlConnection db = new SqlConnection(cn);
        string query = "select ID, Descripcion from Turno";
        SqlCommand cmd = new SqlCommand(query, db);
        db.Open();

        List<sitio> list1 = new List<sitio>();
        using (IDataReader dataReader = cmd.ExecuteReader())
        {
            while (dataReader.Read())
            {
                sitio obj = new sitio();
                if (dataReader["ID"] != DBNull.Value)
                {
                    if (dataReader["ID"] != DBNull.Value) { obj.ID = (dataReader["ID"].ToString()); }
                    if (dataReader["Descripcion"] != DBNull.Value) { obj.Descripcion = (string)dataReader["Descripcion"]; }
                    list1.Add(obj);
                }
            }
            return list1;
        }
    }
    public List<sitio> ListaIntensidad()
    {
        SqlConnection db = new SqlConnection(cn);
        string query = "select ID, Descripcion from Intensidad order by ID ";
        SqlCommand cmd = new SqlCommand(query, db);
        db.Open();

        List<sitio> list5 = new List<sitio>();
        using (IDataReader dataReader = cmd.ExecuteReader())
        {
            while (dataReader.Read())
            {
                sitio obj = new sitio();
                if (dataReader["ID"] != DBNull.Value)
                {
                    if (dataReader["ID"] != DBNull.Value) { obj.ID = (dataReader["ID"].ToString()); }
                    if (dataReader["Descripcion"] != DBNull.Value) { obj.Descripcion = (string)dataReader["Descripcion"]; }
                    list5.Add(obj);
                }
            }
            return list5;
        }
    }
    public List<sitio> ListaOximetro()
    {
        SqlConnection db = new SqlConnection(cn);
        string query = "select ID, Descripcion from Oximetro order by ID ";
        SqlCommand cmd = new SqlCommand(query, db);
        db.Open();

        List<sitio> list5 = new List<sitio>();
        using (IDataReader dataReader = cmd.ExecuteReader())
        {
            while (dataReader.Read())
            {
                sitio obj = new sitio();
                if (dataReader["ID"] != DBNull.Value)
                {
                    if (dataReader["ID"] != DBNull.Value) { obj.ID = (dataReader["ID"].ToString()); }
                    if (dataReader["Descripcion"] != DBNull.Value) { obj.Descripcion = (string)dataReader["Descripcion"]; }
                    list5.Add(obj);
                }
            }
            return list5;
        }

    }
    public ActionResult NSintomas(string nomina)
    {
        ViewData["nombre"] = Session["Nombre"];
        ViewData["Nomina"] = Session["Nomina"];
        return View();
    }
    public ActionResult Update(trabajador st, int boton, string telefono, string nomina1, string sitio, string area, string proceso, string turno,int? personalvulne)
    {
        if (personalvulne == null)
        {
                personalvulne = 0;
        }
        ListaIntenso();
        ListaO();
        List<trabajador> t = new List<trabajador>();
        SqlConnection sqlconn = new SqlConnection(cn);
        DataTable dt = new DataTable();
        switch (boton)
        {
            case 1:
                ViewData["nombre"] = Session["Nombre"];
                ViewData["Nomina"] = Session["Nomina"];
                string sqlquery = "UPDATE Trabajador SET IdSitio = " + sitio + ", IdArea = " + area + ", IdProceso = " + proceso + ", IdTurno = " + turno + ",  Telefono = '" + telefono + "', RegresarAlMonitoreo = 1, Vulnerable = '"+ personalvulne + "' where Nomina = '" + (string)Session["Nomina"] + "'";
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                sqlcomm.ExecuteNonQuery();
                sqlconn.Close();
                return View("NSintomas");
            case 2:
                ViewData["nombre"] = Session["Nombre"];
                string sqlquery1 = "UPDATE Trabajador SET IdSitio = " + sitio + ", IdArea = " + area + ", IdProceso = " + proceso + ", IdTurno = " + turno + ",  Telefono = '" + telefono + "', RegresarAlMonitoreo = 1, Vulnerable = '" + personalvulne + "' where Nomina = '" + (string)Session["Nomina"] + "'";
                sqlconn.Open();
                SqlCommand sqlcomm1 = new SqlCommand(sqlquery1, sqlconn);
                sqlcomm1.ExecuteNonQuery();
                sqlconn.Close();
                return View("MonitoreoPS");
            case 3:
                ViewData["nombre"] = Session["Nombre"];
                string sqlquery2 = "UPDATE Trabajador SET IdSitio = " + sitio + ", IdArea = " + area + ", IdProceso = " + proceso + ", IdTurno = " + turno + ",  Telefono = '" + telefono + "', RegresarAlMonitoreo = 0, Vulnerable = '" + personalvulne + "' where Nomina = '" + (string)Session["Nomina"] + "'";
                sqlconn.Open();
                SqlCommand sqlcomm2 = new SqlCommand(sqlquery2, sqlconn);
                sqlcomm2.ExecuteNonQuery();
                sqlconn.Close();
                return View("ContactoCOVID");
            case 4:
                ViewData["nombre"] = Session["Nombre"];
                string sqlquery3 = "UPDATE Trabajador SET IdSitio = " + sitio + ", IdArea = " + area + ", IdProceso = " + proceso + ", IdTurno = " + turno + ",  Telefono = '" + telefono + "', RegresarAlMonitoreo = 0, Vulnerable = '" + personalvulne + "' where Nomina = '" + (string)Session["Nomina"] + "'";
                sqlconn.Open();
                SqlCommand sqlcomm3 = new SqlCommand(sqlquery3, sqlconn);
                sqlcomm3.ExecuteNonQuery();
                sqlconn.Close();
                return View("Sospecha");
            case 5:
                ListaIntenso();
                ListaO();
                ViewData["nombre"] = Session["Nombre"];
                string sqlquery4 = "UPDATE Trabajador SET IdSitio = " + sitio + ", IdArea = " + area + ", IdProceso = " + proceso + ", IdTurno = " + turno + ",  Telefono = '" + telefono + "', RegresarAlMonitoreo = 0, Vulnerable = '" + personalvulne + "' where Nomina = '" + (string)Session["Nomina"] + "'";
                sqlconn.Open();
                SqlCommand sqlcomm4 = new SqlCommand(sqlquery4, sqlconn);
                sqlcomm4.ExecuteNonQuery();
                sqlconn.Close();
                return View("PositivoCOVID");
            case 6:
                return View("Confirmacion");
            case 7:
                ViewData["nombre"] = Session["Nombre"];
                string sqlquery5 = "UPDATE Trabajador SET RegresarAlMonitoreo = '1', RegresarASospecha = '0', RegresarAPositivo = '0' WHERE Nomina = '" + Session["Nomina"] +"'";
                sqlconn.Open();
                SqlCommand sqlcomm5 = new SqlCommand(sqlquery5, sqlconn);
                sqlcomm5.ExecuteNonQuery();
                sqlconn.Close();
                return View("NSintomas");
            case 8:
                Inicio(st, (string)Session["Nomina"]);
                return View("Inicio");
                }
        return View("Inicio");
    }
    public ActionResult BotonesInicio()
    {
        return View();
    }
    public ActionResult YesOrNot()
    {
        return View();
    }
    public ActionResult Monitoreo()
    {
        return View();
    }
    public ActionResult LeveAdicionalGrave(string temp, int? ageInputId, int? ageOutputName, int? sintoma1, int? sintoma2, int? sintoma3, int? sintoma4, int? sintoma5, int? sintoma6, int? sintoma7, int? sintoma8, int? sintoma9, int? sintoma10, int? sintoma11, int? sintoma12, int? sintoma13, int? sintoma14, int? sintoma15)
    {
        ListaIntenso();
        ListaO();
        List<sintomas> t = new List<sintomas>();
        SqlConnection sqlconn = new SqlConnection(cn);
        DataTable dt = new DataTable();
        ViewData["nombre"] = Session["Nombre"];
        ViewData["Nomina"] = Session["Nomina"];
        if (Convert.ToDouble(temp) >= 37.5)
        {
            sintoma1 = 1;
        }
        string sqlquery4 = "INSERT INTO MSintomas (Nomina, Fecha, IdMonitoreo, Temperatura, Fiebre37, Tosseca, Cansancio, MolestiasDolores,  DolorGarganta, Diarrea, Conjuntivitis, DolorCabeza, PerdidaSentidos, ErupcionesCutaneasPerdidaColor, DificultadRespirar,  DolorPecho, IncapacidadHablarMoverse, Estuveencontacto, Dipositivo) VALUES (" +
                            (string)Session["Nomina"] + ", GETDATE(), 1 ,'" + temp.ToString() + "', " + sintoma1 + ", " + sintoma2 + ", " + sintoma3 + ", " + sintoma4 + ", " + sintoma5 + ", " + sintoma6 + "" +
                            ", " + sintoma7 + ", " + sintoma8 + ", " + sintoma9 + ", " + sintoma10 + ", " + sintoma11 + ", " + sintoma12 + ", " + sintoma13 + ", " + sintoma14 + ", " + sintoma15 + " )";
        sqlconn.Open();
        SqlCommand sqlcomm4 = new SqlCommand(sqlquery4, sqlconn);
        sqlcomm4.ExecuteNonQuery();
        sqlconn.Close();

        //Vistas
        if (sintoma14 >= 1 && sintoma15 == 0)
        {
            ViewData["nombre"] = Session["Nombre"];
            string sqlquery5 = "UPDATE Trabajador SET RegresarAlMonitoreo = '0', RegresarASospecha = 1, RegresarAPositivo = 0 WHERE Nomina = '" + Session["Nomina"] + "'";
            sqlconn.Open();
            SqlCommand sqlcomm5 = new SqlCommand(sqlquery5, sqlconn);
            sqlcomm5.ExecuteNonQuery();
            sqlconn.Close();
            return View("ContactoCOVID");
        }

        if (sintoma15 >= 1)
        {
            ViewData["nombre"] = Session["Nombre"];
            string sqlquery6 = "UPDATE Trabajador SET RegresarAlMonitoreo = '0', RegresarASospecha = 0, RegresarAPositivo = 1 WHERE Nomina = '" + Session["Nomina"] + "'";
            sqlconn.Open();
            SqlCommand sqlcomm6 = new SqlCommand(sqlquery6, sqlconn);
            sqlcomm6.ExecuteNonQuery();
            sqlconn.Close();
            return View("PositivoCOVID");
        }
        if (sintoma11 >= 1 || sintoma12 >= 1 || sintoma13 >= 1)
        {
            return View("Grave");
        }

        if (sintoma1 == 0 && sintoma2 == 0 && sintoma3 == 0 && sintoma4 == 0 && sintoma5 == 0 && sintoma6 == 0 && sintoma7 == 0 && sintoma8 == 0 && sintoma9 == 0 && sintoma10 == 0 && sintoma11 == 0 && sintoma12 == 0 && sintoma13 == 0 && sintoma14 == 0 && sintoma15 == 0)
        {
            return View("SigueConTuVida");
        }

        return View("LeveAdicional");
    }
    public ActionResult LeveAdicional()
    {
        ViewData["nombre"] = Session["Nombre"];
        return View();
    }
    public ActionResult Grave()
    {
        ViewData["nombre"] = Session["Nombre"];
        return View();
    }
    public ActionResult MonitoreoPS()
    {
        ViewData["nombre"] = Session["Nombre"];
        return View();
    }
    public ActionResult Sospecha()
    {
        ViewData["nombre"] = Session["Nombre"];
        return View();
    }
    public ActionResult PositivoCOVID()
    {
        ViewData["nombre"] = Session["Nombre"];
        return View();
    }
    //Monitoreo Por Sintomas
    public ActionResult SubirArchivos(HttpPostedFileBase file, int? nivel, int? nivel1, int? nivel2, int? nivel3, int? nivel4, int? nivel5, int? nivel6, int? nivel7, int? nivel8, int? nivel9, int? nivel10, int? nivel11, int? nivel12, int? nivel13, string temp, int? sintoma14, int? sintoma15)
    {
        ViewData["nombre"] = Session["Nombre"];
        List<sintomas> t = new List<sintomas>();
        SqlConnection sqlconn = new SqlConnection(cn);
        DataTable dt = new DataTable();

        if (nivel == null)
        {
            nivel = 0;
        }
        if (nivel1 == null)
        {
            nivel1 = 0;
        }
        if (nivel2 == null)
        {
            nivel2 = 0;
        }
        if (nivel3 == null)
        {
            nivel3 = 0;
        }
        if (nivel4 == null)
        {
            nivel4 = 0;
        }
        if (nivel5 == null)
        {
            nivel5 = 0;
        }
        if (nivel6 == null)
        {
            nivel6 = 0;
        }
        if (nivel7 == null)
        {
            nivel7 = 0;
        }
        if (nivel8 == null)
        {
            nivel8 = 0;
        }
        if (nivel9 == null)
        {
            nivel9 = 0;
        }
        if (nivel10 == null)
        {
            nivel10 = 0;
        }
        if (nivel11 == null)
        {
            nivel11 = 0;
        }
        if (nivel12 == null)
        {
            nivel12 = 0;
        }
        if (nivel13 == null)
        {
            nivel13 = 0;
        }
        if(sintoma14 == null)
        {
            sintoma14 = 0;
        }
        if (sintoma15 == null)
        {
            sintoma15 = 0;
        }
            if (file == null)
        {
            string sqlquery4 = "INSERT INTO MSintomas (Nomina, Fecha, IdMonitoreo, Temperatura, Fiebre37, Tosseca, Cansancio, MolestiasDolores,  DolorGarganta, Diarrea, Conjuntivitis, DolorCabeza, PerdidaSentidos, ErupcionesCutaneasPerdidaColor, DificultadRespirar,  DolorPecho, IncapacidadHablarMoverse, Oximetro, Estuveencontacto, Dipositivo) VALUES (" + 
                    (string)Session["Nomina"] + ",GETDATE(), 2," + temp + ", " + nivel + " , " + nivel1 + ", " + nivel2 + ", " + nivel3 + ", " + nivel4 + ", " + nivel5 + "" +
                    ", " + nivel6 + ", " + nivel7 + ", " + nivel8 + ", " + nivel9 + ", " + nivel10 + ", " + nivel11 + ", " + nivel12 + ", " + nivel13 + ", " + sintoma14 + ", " + sintoma15 + ")";
                sqlconn.Open();
                SqlCommand sqlcomm4 = new SqlCommand(sqlquery4, sqlconn);
                sqlcomm4.ExecuteNonQuery();
                sqlconn.Close();

            }
        else
        {
            //CargarArchivo
            string archivo = "~/Uploads/" + (DateTime.Now.ToString("yyyyMMdd") + "-" + file.FileName).ToLower();
            file.SaveAs(Server.MapPath(archivo));
                //Monitoreo Sintomas ID=4, Monitoreo Sospechoso ID=5
                string sqlquery4 = "INSERT INTO MSintomas (Nomina, Fecha, IdMonitoreo, Temperatura, Fiebre37, Tosseca, Cansancio, MolestiasDolores,  DolorGarganta, Diarrea, Conjuntivitis, DolorCabeza, PerdidaSentidos, ErupcionesCutaneasPerdidaColor, DificultadRespirar,  DolorPecho, IncapacidadHablarMoverse, Oximetro,Receta) VALUES (" +
                        (string)Session["Nomina"] + ",GETDATE(), 2 ," + nivel + ", " + temp + " , " + nivel1 + ", " + nivel2 + ", " + nivel3 + ", " + nivel4 + ", " + nivel5 + "" +
                    ", " + nivel6 + ", " + nivel7 + ", " + nivel8 + ", " + nivel9 + ", " + nivel10 + ", " + nivel11 + ", " + nivel12 + ", " + nivel13 + ", '" + archivo + "', " + sintoma14 + ", " + sintoma15 + ")";
                sqlconn.Open();
                SqlCommand sqlcomm4 = new SqlCommand(sqlquery4, sqlconn);
                sqlcomm4.ExecuteNonQuery();
                sqlconn.Close();
              
        }
        if (nivel10 != 0 || nivel11 != 0 || nivel12 != 0)
        {
            return View("Grave2");
        }
        return View("LeveAdicional2");
    }
    //Monitoreo a Tuve contacto con un sospechoso o positivo a covid
    public ActionResult SubirArchivos2(HttpPostedFileBase file, int? nivel, int? nivel1, int? nivel2, int? nivel3, int? nivel4, int? nivel5, int? nivel6, int? nivel7, int? nivel8, int? nivel9, int? nivel10, int? nivel11, int? nivel12, int? nivel13, string temp, int? sintoma15)
    {
        ViewData["nombre"] = Session["Nombre"];
        List<sintomas> t = new List<sintomas>();
        SqlConnection sqlconn = new SqlConnection(cn);
        DataTable dt = new DataTable();
        if (nivel == null)
        {
            nivel = 0;
        }
        if (Convert.ToDouble(temp) >= 37.5)
        {
            nivel = 1;
        }
        if (nivel1 == null)
        {
            nivel1 = 0;
        }
        if (nivel2 == null)
        {
            nivel2 = 0;
        }
        if (nivel3 == null)
        {
            nivel3 = 0;
        }
        if (nivel4 == null)
        {
            nivel4 = 0;
        }
        if (nivel5 == null)
        {
            nivel5 = 0;
        }
        if (nivel6 == null)
        {
            nivel6 = 0;
        }
        if (nivel7 == null)
        {
            nivel7 = 0;
        }
        if (nivel8 == null)
        {
            nivel8 = 0;
        }
        if (nivel9 == null)
        {
            nivel9 = 0;
        }
        if (nivel10 == null)
        {
            nivel10 = 0;
        }
        if (nivel11 == null)
        {
            nivel11 = 0;
        }
        if (nivel12 == null)
        {
            nivel12 = 0;
        }
        if (nivel13 == null)
        {
            nivel13 = 0;
        }
        if (sintoma15 == null)
        {
            sintoma15 = 0;
        }

        if (file == null)
        {
            string sqlquery4 = "INSERT INTO MSintomas (Nomina, Fecha, IdMonitoreo, Temperatura, Fiebre37, Tosseca, Cansancio, MolestiasDolores,  DolorGarganta, Diarrea, Conjuntivitis, DolorCabeza, PerdidaSentidos, ErupcionesCutaneasPerdidaColor, DificultadRespirar,  DolorPecho, IncapacidadHablarMoverse, Oximetro, Estuveencontacto, Dipositivo) VALUES (" +
                    (string)Session["Nomina"] + ",GETDATE(), 3," + temp + ", " + nivel + " , " + nivel1 + ", " + nivel2 + ", " + nivel3 + ", " + nivel4 + ", " + nivel5 + "" +
                    ", " + nivel6 + ", " + nivel7 + ", " + nivel8 + ", " + nivel9 + ", " + nivel10 + ", " + nivel11 + ", " + nivel12 + ", " + nivel13 + ", 1 ," + sintoma15 + ")";
            sqlconn.Open();
            SqlCommand sqlcomm4 = new SqlCommand(sqlquery4, sqlconn);
            sqlcomm4.ExecuteNonQuery();
            sqlconn.Close();

        }
        else
        {
            //CargarArchivo
            string archivo = "~/Uploads/" + (DateTime.Now.ToString("yyyyMMdd") + "-" + file.FileName).ToLower();
            file.SaveAs(Server.MapPath(archivo));
            //Monitoreo Sintomas ID=4, Monitoreo Sospechoso ID=5
            string sqlquery4 = "INSERT INTO MSintomas (Nomina, Fecha, IdMonitoreo, Temperatura, Fiebre37, Tosseca, Cansancio, MolestiasDolores,  DolorGarganta, Diarrea, Conjuntivitis, DolorCabeza, PerdidaSentidos, ErupcionesCutaneasPerdidaColor, DificultadRespirar,  DolorPecho, IncapacidadHablarMoverse, Oximetro,Receta, Estuveencontacto, Dipositivo) VALUES (" +
                    (string)Session["Nomina"] + ",GETDATE(), 3 ," + nivel + ", " + temp + " , " + nivel1 + ", " + nivel2 + ", " + nivel3 + ", " + nivel4 + ", " + nivel5 + "" +
                ", " + nivel6 + ", " + nivel7 + ", " + nivel8 + ", " + nivel9 + ", " + nivel10 + ", " + nivel11 + ", " + nivel12 + ", " + nivel13 + ", '" + archivo + "', 1 ," + sintoma15 + ")";
                sqlconn.Open();
            SqlCommand sqlcomm4 = new SqlCommand(sqlquery4, sqlconn);
            sqlcomm4.ExecuteNonQuery();
            sqlconn.Close();
        }
        if (sintoma15 >= 1 )
        {
            ViewData["nombre"] = Session["Nombre"];
            string sqlquery5 = "UPDATE Trabajador SET RegresarAlMonitoreo = '0', RegresarASospecha = '0', RegresarAPositivo = '1' WHERE Nomina = '" + Session["Nomina"] + "'";
            sqlconn.Open();
            SqlCommand sqlcomm5 = new SqlCommand(sqlquery5, sqlconn);
            sqlcomm5.ExecuteNonQuery();
            sqlconn.Close();
        }
        if (nivel10 != 0 || nivel11 != 0 || nivel12 != 0)
        {
            return View("Grave2");
        }

        return View("LeveAdicional2");            
    }
    //Monitoreo Sali Positivo.
    public ActionResult SubirArchivos3(HttpPostedFileBase file, int? nivel, int? nivel1, int? nivel2, int? nivel3, int? nivel4, int? nivel5, int? nivel6, int? nivel7, int? nivel8, int? nivel9, int? nivel10, int? nivel11, int? nivel12, int? nivel13, string temp)
    {
        ViewData["nombre"] = Session["Nombre"];
        List<sintomas> t = new List<sintomas>();
        SqlConnection sqlconn = new SqlConnection(cn);
        DataTable dt = new DataTable();
        if (nivel == null)
        {
            nivel = 0;
        }
        if (nivel1 == null)
        {
            nivel1 = 0;
        }
        if (nivel2 == null)
        {
            nivel2 = 0;
        }
        if (nivel3 == null)
        {
            nivel3 = 0;
        }
        if (nivel4 == null)
        {
            nivel4 = 0;
        }
        if (nivel5 == null)
        {
            nivel5 = 0;
        }
        if (nivel6 == null)
        {
            nivel6 = 0;
        }
        if (nivel7 == null)
        {
            nivel7 = 0;
        }
        if (nivel8 == null)
        {
            nivel8 = 0;
        }
        if (nivel9 == null)
        {
            nivel9 = 0;
        }
        if (nivel10 == null)
        {
            nivel10 = 0;
        }
        if (nivel11 == null)
        {
            nivel11 = 0;
        }
        if (nivel12 == null)
        {
            nivel12 = 0;
        }
        if (nivel13 == null)
        {
            nivel13 = 0;
        }
          
            if (file == null)
            {
                string sqlquery4 = "INSERT INTO MSintomas (Nomina, Fecha, IdMonitoreo, Temperatura, Fiebre37, Tosseca, Cansancio, MolestiasDolores,  DolorGarganta, Diarrea, Conjuntivitis, DolorCabeza, PerdidaSentidos, ErupcionesCutaneasPerdidaColor, DificultadRespirar,  DolorPecho, IncapacidadHablarMoverse, Oximetro) VALUES (" +
                        (string)Session["Nomina"] + ",GETDATE(), 4," + temp + ", " + nivel + " , " + nivel1 + ", " + nivel2 + ", " + nivel3 + ", " + nivel4 + ", " + nivel5 + "" +
                        ", " + nivel6 + ", " + nivel7 + ", " + nivel8 + ", " + nivel9 + ", " + nivel10 + ", " + nivel11 + ", " + nivel12 + ", " + nivel13 + ")";
                sqlconn.Open();
                SqlCommand sqlcomm4 = new SqlCommand(sqlquery4, sqlconn);
                sqlcomm4.ExecuteNonQuery();
                sqlconn.Close();

            }
            else
            {
                //CargarArchivo
                string archivo = "~/Uploads/" + (DateTime.Now.ToString("yyyyMMdd") + "-" + file.FileName).ToLower();
                file.SaveAs(Server.MapPath(archivo));
                //Monitoreo Sintomas ID=4, Monitoreo Sospechoso ID=5
                string sqlquery4 = "INSERT INTO MSintomas (Nomina, Fecha, IdMonitoreo, Temperatura, Fiebre37, Tosseca, Cansancio, MolestiasDolores,  DolorGarganta, Diarrea, Conjuntivitis, DolorCabeza, PerdidaSentidos, ErupcionesCutaneasPerdidaColor, DificultadRespirar,  DolorPecho, IncapacidadHablarMoverse, Oximetro,Receta) VALUES (" +
                        (string)Session["Nomina"] + ",GETDATE(), 4 ," + nivel + ", " + temp + " , " + nivel1 + ", " + nivel2 + ", " + nivel3 + ", " + nivel4 + ", " + nivel5 + "" +
                    ", " + nivel6 + ", " + nivel7 + ", " + nivel8 + ", " + nivel9 + ", " + nivel10 + ", " + nivel11 + ", " + nivel12 + ", " + nivel13 + ", '" + archivo + "')";
                sqlconn.Open();
                SqlCommand sqlcomm4 = new SqlCommand(sqlquery4, sqlconn);
                sqlcomm4.ExecuteNonQuery();
                sqlconn.Close();

            }
            return View("PositivoCOVIDReco");
    }
    public ActionResult Formulario(int? evento, int? viaje, int? contacto, string fechacontacto, int? vive, string convivencia, string lugarcontagio, string fechacontagio, int? sintoma, string fechasintoma, string estadosalud, string sintomasprev, string ultimodia, string contactolaboral, string interaccion, string areas )
    {
        ViewData["nombre"] = Session["Nombre"];
        string vacio = null;
        if (evento == null)
        {
        evento = 0;
        }
        if (viaje == null)
        {
            viaje = 0;
        }
        if (contacto == null)
        {
            contacto = 0;
        }
        if (vive == null)
        {
            vive = 0;
        }
        if (sintoma == null)
        {
            sintoma = 0;
        }
        if(fechacontacto == string.Empty)
        {
            fechacontacto = vacio;
        }
        List<contacto> t = new List<contacto>();
        SqlConnection sqlconn = new SqlConnection(cn);
        DataTable dt = new DataTable();
        ViewData["nombre"] = Session["Nombre"];
        string sqlquery = "Insert Into ContactoSC (Nomina, Fecha, Evento, Viaje, Contacto, FechaContacto, Vive, Convivencia, LugarContagio, FechaContagio, Sintoma, FechaSintoma, EstadoSalud, SintomasPrevalecen, UltimoDiaLaboral, ContactoLaboral, Interaccion, Areas)" +
        " Values (" + (string)Session["Nomina"] + ", GETDATE(), " + evento + ", " + viaje + ", " + contacto + ", '" + fechacontacto + "', " + vive + ", '" + convivencia + "', '" + lugarcontagio + "', '" + fechacontagio + "', " + sintoma + ", '" + fechasintoma + "', '" + estadosalud + "', '" + sintomasprev + "', '" + ultimodia + "', '" + contactolaboral + "', '" + interaccion + "', '" + areas + "')";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();


        return View("ContactoReco");
    }
    public ActionResult ContactoReco()
    {
        return View();
    }
    void ListaIntenso()
    {
    HomeController Home = new HomeController();
    List<sitio> pcontent4 = new List<sitio>();
    {
        pcontent4 = Home.ListaIntensidad();
    };
    List<SelectListItem> intensoList = new List<SelectListItem>();
    //List<string> items = new List<string>();
    foreach (var item in pcontent4)
    {
        intensoList.Add(new SelectListItem
        {
            Text = item.Descripcion,
            Value = item.ID
        });
    }
    ViewBag.intenso = intensoList;
}
    void ListaS()
    {
        HomeController Home = new HomeController();
        //Lista Sitio
        List<sitio> pcontent = new List<sitio>();
        {
            pcontent = Home.ListaSitio();
        };
        List<SelectListItem> sitioList = new List<SelectListItem>();
        //List<string> items = new List<string>();
        foreach (var item in pcontent)
        {
            sitioList.Add(new SelectListItem
            {
                Text = item.Descripcion,
                Value = item.ID
            });
        }
        ViewBag.sitioList = sitioList;
    }
    void ListaA()
    {
        HomeController Home = new HomeController();
        //Lista Area
        List<sitio> pcontent1 = new List<sitio>();
        {
            pcontent1 = Home.ListaArea();
        };
        List<SelectListItem> areaList = new List<SelectListItem>();
        //List<string> items = new List<string>();
        foreach (var item in pcontent1)
        {
            areaList.Add(new SelectListItem
            {
                Text = item.Descripcion,
                Value = item.ID
            });
        }
        ViewBag.areaList = areaList;
    }
    void ListaP()
    {
        HomeController Home = new HomeController();
        //Lista Proceso
        List<sitio> pcontent2 = new List<sitio>();
        {
            pcontent2 = Home.ListaProceso();
        };
        List<SelectListItem> procList = new List<SelectListItem>();
        //List<string> items = new List<string>();
        foreach (var item in pcontent2)
        {
            procList.Add(new SelectListItem
            {
                Text = item.Descripcion,
                Value = item.ID
            });
        }
        ViewBag.procList = procList;
    }
    void ListaT()
    {
        HomeController Home = new HomeController();
        //Lista Turno
        List<sitio> pcontent3 = new List<sitio>();
        {
            pcontent3 = Home.ListaTurno();
        };
        List<SelectListItem> turnoList = new List<SelectListItem>();
        //List<string> items = new List<string>();
        foreach (var item in pcontent3)
        {
            turnoList.Add(new SelectListItem
            {
                Text = item.Descripcion,
                Value = item.ID
            });
        }
        ViewBag.turnoList = turnoList;
    }
    void ListaO()
    {
            HomeController Home = new HomeController();
            //Lista Turno
            List<sitio> pcontent7 = new List<sitio>();
            {
                pcontent7 = Home.ListaOximetro();
            };
            List<SelectListItem> oxList = new List<SelectListItem>();
            //List<string> items = new List<string>();
            foreach (var item in pcontent7)
            {
                oxList.Add(new SelectListItem
                {
                    Text = item.Descripcion,
                    Value = item.ID
                });
            }
            ViewBag.oximetro = oxList;
    }
    public ActionResult SigueConTuVida()
    {
            return View();
    }

}
}