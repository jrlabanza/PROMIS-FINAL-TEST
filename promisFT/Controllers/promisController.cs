using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using promisFT.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;


namespace promisFT.Controllers
{
    public class GET_FORM_ID //POST DATA
    {
        public int id { get; set; }

    }

    public class FOL_DATA
    {
        public string machineID { get; set; }
        public string machinePF { get; set; }
        public string pkgLine { get; set; }
        public string stsOwner { get; set; }
        public string stsDes { get; set; }
        public string prodName { get; set; }
        public string Prod_Line { get; set; }
        public string lotNo { get; set; }
        public double uph { get; set; }
        public int bin1 { get; set; }
        public string unpicked_device { get; set; }
        public string marking_surface { get; set; }
        public string bump_leads { get; set; }
        public string missing { get; set; }
        public string lsg_sample { get; set; }
        public string lsg_repair_type { get; set; }
        public string waferID { get; set; }
        public string failure_mechanism { get; set; }
        public string part_specification { get; set; }
        public int pbft_min { get; set; }
        public int pbft_max { get; set; }
        public int total_ng_units_result { get; set; }
        public string pkgType { get; set; }
        public string remarks { get; set; }
        public int vi5_sample { get; set; }
        public string group { get; set; }
        public string user { get; set; }
        public string date1 { get; set; }
        public string date2 { get; set; }
        public string date3 { get; set; }
        public string swi_mode { get; set; }
        public string swi { get; set; }
        public string carrier_tape_lot_no { get; set; }
        public string cover_tape_lot_no { get; set; }
        public string process { get; set; }
        public string track_in { get; set; }
        public string track_out { get; set; }
        public string setup_flg { get; set; }


    }
    public class promisController : BaseController
    {
        FTMod promisObject = new FTMod();
        // for testing queries
        public JsonResult testing()
        {
            var results = promisObject.export_to_excel();

            return Json(results, JsonRequestBehavior.AllowGet);
        }
        
        //
        // GET: /promis/

        public ActionResult ftStatus()
        {
            return View();
        }

        public ActionResult swStatus() 
        {
            return View();
        }

        public ActionResult nwStatus()
        {
            return View();
        }

        public JsonResult show_filtered_machine_WLP(string statOwner, string machine, string machineID)
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = promisObject.show_filtered_machine_WLP(statOwner, machine, machineID);

            return Json(results);
        }

        public JsonResult show_nw_machines()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = promisObject.show_nw_machines();

            return Json(results);
        }

        public JsonResult show_sw_machines()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = promisObject.show_nw_machines();

            return Json(results);
        }

        public JsonResult show_all_machines()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = promisObject.show_all_machines();

            return Json(results);
        }

        //Filter

        //public JsonResult show_process(string location)
        //{
        //    List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

        //    results = promisObject.show_process(location);

        //    return Json(results);
        //}

        public JsonResult show_statusOwner()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = promisObject.show_statusowner();

            return Json(results);
        }

        public JsonResult show_testerPF()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = promisObject.show_testerPF();

            return Json(results);
        }

        public JsonResult show_testerID_onload()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = promisObject.show_testerID_onload();

            return Json(results);
        }

        public JsonResult show_testerID(string pfid)
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = promisObject.show_testerID(pfid);

            return Json(results);
        }

        //Update Form

        public JsonResult show_data(GET_FORM_ID data)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = promisObject.show_Data(data.id);

            return Json(results);

        }

        public JsonResult get_status_owner()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = promisObject.get_status_owner();

            return Json(results);
        }

        public JsonResult get_status(string stsOwner)
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = promisObject.get_status(stsOwner);

            return Json(results);
        }

        public JsonResult get_uph(string machinePF, string family) 
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = promisObject.get_uph(machinePF, family);

            return Json(results);
        }

        public JsonResult get_uph_check(string testerPF, string handlerPF, string family)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = promisObject.get_uph_check(testerPF, handlerPF, family);

            return Json(results);
        }

        //public JsonResult get_product_name(string tester)
        //{
        //    IDictionary<string, string> results = new Dictionary<string, string>();

        //    results = promisObject.get_product_name(tester);

        //    return Json(results);

        //}

        public JsonResult get_package_data(string id)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = promisObject.get_package_type(id);

            return Json(results);

        }

        public JsonResult get_handler_mode(string handlerID)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = promisObject.get_handler_onLoad(handlerID);

            return Json(results);
        }

        public JsonResult get_prod_line()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = promisObject.get_prod_line();

            return Json(results);
        }

        public JsonResult get_device()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = promisObject.get_device();

            return Json(results);
        }

        //Validation

        public JsonResult get_user()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = promisObject.get_all_user();

            return Json(results);
        }

        public JsonResult hash_test(string pass)
        {
           
            var results = this.GetHashMD5(pass);
            return Json(results);
        }

        public JsonResult check_user(string user, string pass)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = promisObject.check_user(user, pass);

            return Json(results);

        }

        public JsonResult check_lot(FOL_DATA access)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = promisObject.check_lot(access.machineID, access.lotNo);

            return Json(results);

        }

        // Export to Excel

        public JsonResult export_allmachines()
        {
            List<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            results = promisObject.export_allmachines();

            return Json(results);
        }

        //Normal Machine Updating

        [HttpPost] //Posting in C#
        [ValidateInput(true)] // Checks if inputs are true
        public JsonResult update_machine(FOL_DATA access)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();


            promisObject.insert_Data(access.machineID, access.machinePF, access.stsOwner, access.stsDes, access.prodName, access.lotNo.ToUpper(), access.pkgType, access.remarks, access.group, access.user, access.date3, access.pkgLine, access.waferID, access.failure_mechanism, access.part_specification, access.lsg_repair_type, access.pbft_min, access.pbft_max, access.swi_mode, access.swi, access.carrier_tape_lot_no, access.cover_tape_lot_no, access.setup_flg);

            results["done"] = "TRUE";
            results["msg"] = "<strong class='success'>UPDATE SUCCESSFULLY</strong>";
            return Json(results);

        }

        [HttpPost] //Posting in C#
        [ValidateInput(true)] // Checks if inputs are true
        public JsonResult update_machine_history(FOL_DATA access)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();


            promisObject.insert_Data_History(access.machineID, access.stsDes, access.date1, access.date2, access.user, access.remarks, access.prodName, access.lotNo.ToUpper(), access.uph, access.stsOwner, access.group, access.pkgType, access.pbft_min, access.pbft_max, access.pkgLine, access.bin1, access.total_ng_units_result, access.unpicked_device, access.waferID, access.marking_surface, access.failure_mechanism, access.bump_leads, access.part_specification, access.missing, access.lsg_repair_type, access.lsg_sample, access.vi5_sample, access.swi_mode, access.swi, access.carrier_tape_lot_no, access.cover_tape_lot_no, access.setup_flg);

            results["done"] = "TRUE";
            results["msg"] = "<strong class='success'>UPDATE HISTORY SUCCESSFULLY</strong>";
            return Json(results);

        }
        //Tracking Functions//////////////////////////////////////////////////////////

        [HttpPost] //Posting in C#
        [ValidateInput(true)] // Checks if inputs are true
        public JsonResult track_lot(FOL_DATA access)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();


            promisObject.track_lot(access.machineID, access.track_in, access.track_out, access.lotNo, access.user);

            //if (access.track_out == "1")
            //{
            //    promisObject.pbft_reset(access.machineID);
            //}

            results["done"] = "TRUE";
            results["msg"] = "<strong class='success'>UPDATE TRACK DATA SUCCESSFULLY</strong>";
            return Json(results);

        }

        [HttpPost] //Posting in C#
        [ValidateInput(true)] // Checks if inputs are true
        public JsonResult update_track_lot(FOL_DATA access)
        {

            IDictionary<string, string> results = new Dictionary<string, string>();

            promisObject.track_lot(access.machineID, access.track_in, access.track_out, access.lotNo, access.user);

            //if (access.track_out == "1")
            //{
            //    promisObject.pbft_reset(access.machineID);
            //}

            results["done"] = "TRUE";
            results["msg"] = "<strong class='success'>UPDATE TRACK DATA SUCCESSFULLY</strong>";
            return Json(results);

        }

        public JsonResult check_track_by_machine(FOL_DATA access)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = promisObject.check_track_by_machine(access.machineID);

            return Json(results);

        }

        public JsonResult check_track_by_lot(FOL_DATA access)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = promisObject.check_track_by_lot(access.lotNo);

            return Json(results);

        }

        public JsonResult carrier_tape_check(string carrier_tape_lot_no)
        {
            IDictionary<string, string> results = new Dictionary<string, string>();

            results = promisObject.carrier_tape_check(carrier_tape_lot_no);

            return Json(results); 

        }
    }
}
