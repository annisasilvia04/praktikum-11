﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PerpustakaanAppMVC.Model.Entity;
using PerpustakaanAppMVC.Model.Repository;
using PerpustakaanAppMVC.Model.Context;



namespace PerpustakaanAppMVC.Controller
{
    public class MahasiswaController
    {
        //Deklarasi objek repository uutuk menjalankan operasi CRUD     
        private MahasiswaRepository _repository;

        public int Create(Mahasiswa mhs)
        {
            int result = 0;
            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Npm))
            {
                MessageBox.Show("NPM harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Angkatan))
            {
                MessageBox.Show("Angkatan harus diisi !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _repository = new MahasiswaRepository(context);
                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(mhs);
            }
            if (result > 0)
            {
                MessageBox.Show("Data mahasiswa berhasil disimpan !", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data mahasiswa gagal disimpan !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return result;
        }

        public int Update(Mahasiswa mhs)
        {
            int result = 0;

            if(mhs.Npm != mhs.Npm)
            {
                MessageBox.Show("NPM tidak bisa diganti!!!", "Peringatan",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi update nim
            if (string.IsNullOrEmpty(mhs.Npm))
            {
                MessageBox.Show("NPM harus diisi !!!", "Peringatan",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi update nama
            if (string.IsNullOrEmpty(mhs.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // Validasi update angkatan
            if (string.IsNullOrEmpty(mhs.Angkatan))
            {
                MessageBox.Show("Angkatan harus diisi !!!", "Peringatan",
                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek repository berdasarkan context
                _repository = new MahasiswaRepository(context);

                // panggil method Update class repository untuk mengupdate data
                result = _repository.Update(mhs);
            }

            if (result > 0)
            {
                MessageBox.Show("Data mahasiswa berhasil diupdate !", "Informasi",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data mahasiswa gagal diupdate !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return result;

        }

        public int Delete(Mahasiswa mhs)
        {
            int result = 0;

            // Validasi delete nim
            if (string.IsNullOrEmpty(mhs.Npm))
            {
                MessageBox.Show("NPM harus diisi !!!", "Peringatan",
                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            //validasi delete nama
            if (string.IsNullOrEmpty(mhs.Nama))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            //validasi delete angkatan
            if (string.IsNullOrEmpty(mhs.Angkatan))
            {
                MessageBox.Show("Angkatan harus diisi !!!", "Peringatan",
                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek repository berdasarkan context
                _repository = new MahasiswaRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(mhs);
            }

            if (result > 0)
            {
                MessageBox.Show("Data mahasiswa berhasil dihapus !", "Informasi",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data mahasiswa gagal dihapus !!!", "Peringatan",
                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return result;
        }

        public List<Mahasiswa> ReadByNama(string nama)
        {
            // membuat objek collection
            List<Mahasiswa> list = new List<Mahasiswa>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new MahasiswaRepository(context);
                // panggil method GetByNama yang ada di dalam class repository
                list = _repository.ReadByNama(nama);
            }
            return list;
        }
        public List<Mahasiswa> ReadAll()
        {
            // membuat objek collection
            List<Mahasiswa> list = new List<Mahasiswa>();
            // membuat objek context menggunakan blok using
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new MahasiswaRepository(context);
                // panggil method GetAll yang ada di dalam class repository
                list = _repository.ReadAll();
            }
            return list;
        }
    }
}
