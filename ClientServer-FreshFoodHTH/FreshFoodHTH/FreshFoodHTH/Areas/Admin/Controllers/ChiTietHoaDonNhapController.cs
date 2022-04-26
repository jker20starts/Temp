﻿using FreshFoodHTH.Models.DAO.Admin;
using FreshFoodHTH.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreshFoodHTH.Areas.Admin.Controllers
{
    public class ChiTietHoaDonNhapController : Controller
    {
        ChiTietHoaDonNhapDAO cthdnDao = new ChiTietHoaDonNhapDAO();
        HoaDonNhapDAO hdnDao = new HoaDonNhapDAO();
        SanPhamDAO spDao = new SanPhamDAO();
        NhaCungCapSanPhamDAO nccspDao = new NhaCungCapSanPhamDAO();
        static Guid IDcurHoaDonNhap;


        // GET: Admin/ChiTietHoaDonNhap
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Guid id)
        {
            ChiTietHoaDonNhap chitietHDN = cthdnDao.GetByID(id);
            return View(chitietHDN);
        }

        public ActionResult Create(Guid idhdn, Guid idncc)
        {
            List<NhaCungCapSanPham> listSPCungUng = nccspDao.GetListSPCungUngByIDNhaCungCap(idncc);
            ViewBag.ListSPCungUng = new SelectList(listSPCungUng, "IDSanPham", "SanPham.Ten", "IDSanPham");
            IDcurHoaDonNhap = idhdn;
            ViewBag.IDHoaDonNhap = idhdn;
            ViewBag.MaSoHoaDonNhap = (hdnDao.GetByID(idhdn)).MaSo;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Guid idsanpham, string soluong)
        {
            ChiTietHoaDonNhap chitietHDN = new ChiTietHoaDonNhap();
            chitietHDN.IDChiTietHoaDonNhap = Guid.NewGuid();
            chitietHDN.IDHoaDonNhap = IDcurHoaDonNhap;
            chitietHDN.IDSanPham = idsanpham;
            chitietHDN.DonViTinh = nccspDao.SPCungUng_GetDonViTinh((hdnDao.GetByID(IDcurHoaDonNhap)).IDNhaCungCap, idsanpham);
            chitietHDN.DonGiaNhap = nccspDao.SPCungUng_GetGiaCungUng((hdnDao.GetByID(IDcurHoaDonNhap)).IDNhaCungCap, idsanpham);
            chitietHDN.SoLuong = Convert.ToInt32(soluong);
            chitietHDN.ThanhTien = chitietHDN.DonGiaNhap * chitietHDN.SoLuong;

            if (ModelState.IsValid)
            {
                cthdnDao.Add(chitietHDN);
                return RedirectToAction("Details", "HoaDonNhap", new { id = IDcurHoaDonNhap });
            }
            else
            {
                return View(chitietHDN);
            }
        }

        public ActionResult Edit(Guid id)
        {
            return View(cthdnDao.GetByID(id));
        }

        [HttpPost]
        public ActionResult Edit(Guid id, string soluong)
        {
            ChiTietHoaDonNhap chitietHDN = cthdnDao.GetByID(id);
            var thanhTienCu = chitietHDN.ThanhTien;
            chitietHDN.SoLuong = Convert.ToInt32(soluong);
            chitietHDN.ThanhTien = chitietHDN.DonGiaNhap * chitietHDN.SoLuong;

            if (ModelState.IsValid)
            {
                cthdnDao.Edit(chitietHDN, thanhTienCu);
                return RedirectToAction("Details", "HoaDonNhap", new { id = chitietHDN.IDHoaDonNhap });
            }
            else
            {
                return View(chitietHDN);
            }
        }

        public ActionResult Delete(Guid id)
        {
            ChiTietHoaDonNhap chitietHDN = cthdnDao.GetByID(id);
            cthdnDao.Delete(id);
            return RedirectToAction("Details", "HoaDonNhap", new { id = chitietHDN.IDHoaDonNhap });
        }
    }
}