﻿using FreshFoodHTH.Models.DAO.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreshFoodHTH.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Admin/Dashboard
        public DonHangDAO dhDao = new DonHangDAO();
        public HoaDonNhapDAO hdnDao = new HoaDonNhapDAO();
        public NguoiDungDAO ndDao = new NguoiDungDAO();

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            //Tính theo khoảng thời gian từ đầu tháng -> hiện tại
            ViewBag.TongHoaDonNhap = hdnDao.TongHoaDonNhap();
            ViewBag.TongDonHang = dhDao.TongDonHang();
            ViewBag.DoanhThu = dhDao.DoanhThu();
            ViewBag.TongSoThanhVien = ndDao.TongSoThanhVien();
            return View();
        }
    }
}