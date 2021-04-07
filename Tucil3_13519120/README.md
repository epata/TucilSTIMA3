# STARIF
> Starif adalah aplikasi GUI berbasis NET versi 5.0 untuk menentukan lintasan terpendek suatu graf dengan menggunakan algoritma A*.

## Table of contents
* [Perancang](#perancang)
* [Deskripsi Singkat Algoritma](#deskripsi-singkat)
* [Requirements](#requirements)
* [Setup](#setup)
* [Contoh Kode](#contoh-kode) 
* [Fitur](#fitur)
* [Status](#status)
* [Referensi](#referensi)

## Perancang
* 13519120 - Epata Tuah
* 13519125 - Habibina Arif Muzayyan

## Deskripsi Singkat Algoritma
Algoritma A* merupakan algoritma yang sering digunakan dalam penentuan rute.
Tujuan utama algoritma ini adalah menghindari jalur yang memiliki bobot terbesar. Fungsi algoritma A* adalah f(n) = g(n) + h(n).
* g(n) adalah bobot yang dibutuhkan untuk mencapai simpul n
* h(n) adalah perkiraan bobot dari simpul n ke simpul tujuan
* f(n) adalah perkiraan total jalur melalui simpul n ke simpul tujuan

## Requirements
* C#
* Windows 10
* .NET 5.0
* Visual Studio 2019

## Setup
* MSAGL (Library Visualisasi Graf)


Project memanfaatkan perkakas .NET (disarankan menggunakan Visual Studio)
1. Buka Visual Studio
2. Pilih menu Tools
3. Pilih NuGet Package Manager
4. Pilih Package Manager Controls
5. Ketik kode instalasi MSAGL pada terminal yang muncul, yakni


`Install-Package AutomaticGraphLayout -Version 1.1.11`


`Install-Package AutomaticGraphLayout.Drawing -Version 1.1.11`


`Install-Package AutomaticGraphLayout.WpfGraphControl -Version 1.1.11`


`Install-Package AutomaticGraphLayout.GraphViewerGDI -Version 1.1.11`


6. MSAGL telah terinstall

* Build dan Publish Aplikasi
1. Buka Starif.sln
2. Pilih menu Build
3. Pilih Publish Starif
4. Pilih direktori untuk menyimpan hasil publish
5. Pilih Publish
6. Tunggu hingga selesai
7. Program dipublish pada direktori yang telah dipilih

* Membuka Aplikasi
1. Buka Starif.exe
2. Aplikasi dijalankan dan siap dipakai

## Contoh kode 
* Menghitung euclidean distance:
`Math.Sqrt(Math.Pow((A.getX()-B.getX()),2) + Math.Pow((A.getY()-B.getY()),2)));`

## Fitur
* Input file test
* Pilih tempat asal dan tujuan
* Visualisasi graf

## Status
Project is: _finished_

## Referensi
https://informatika.stei.itb.ac.id/~rinaldi.munir/Stmik/2020-2021/Tugas-Kecil-3-(2021).pdf