using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev1_WebApi.Controllers
{

    public class Book
    {
        public int Id { get; set; }
        public string KitapAdi { get; set; }
        public string Yazari { get; set; }
        public string KitapSeriNo { get; set; }

    }


    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public List<Book> booklist;
        public BookController()
        {
            booklist = new List<Book>();

            booklist.Add(new Book { Id = 1, KitapSeriNo = "SN001", KitapAdi = "Beyaz Gemi", Yazari = "Cengi Aytmatov" });
            booklist.Add(new Book { Id = 2, KitapSeriNo = "SN002", KitapAdi = "Don Kişot", Yazari = "Cervantes" });
            booklist.Add(new Book { Id = 3, KitapSeriNo = "SN003", KitapAdi = "Dokuzuncu Hariciye Koğuşu", Yazari = "Peyami Safa" });
            booklist.Add(new Book { Id = 4, KitapSeriNo = "SN004", KitapAdi = "Çalıkuşu", Yazari = "Reşat Nuri Güntekin" });
            booklist.Add(new Book { Id = 5, KitapSeriNo = "SN005", KitapAdi = "Yılkı Atı", Yazari = "Abbas Sayar" });
            booklist.Add(new Book { Id = 6, KitapSeriNo = "SN006", KitapAdi = "Hababam Sınıfı", Yazari = "Rıfat Ilgaz" });

        }


        [HttpPost] //Listeleme
        public List<Book> ListAllBooks()
        {
            return booklist;
        }

        //[HttpGet("{id}")] //FromRoute
        //public IActionResult GetBookById(int id)
        //{

        //    if (id == 0)
        //    {
        //        return Unauthorized();
        //    }
        //    var book = booklist.Where(x => x.Id == id).FirstOrDefault();
        //    if (book is null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(book);
        //}

        [HttpGet] //FromQuery
        public IActionResult GetBookById([FromQuery] int id)
        {
            if (id == 0)
            {
                return Unauthorized();
            }
            var book = booklist.Where(x => x.Id == id).FirstOrDefault();
            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        //[HttpPost] //Kayıt Ekleme
        //public ActionResult Post([FromBody] Book kitap)
        //{
            
        //    booklist.Add(kitap);
        //    return Ok(booklist);
        //}

        [HttpPut] //Güncelleme
        public ActionResult<Book> Put(int id, Book kitap)
        {
            var value = booklist.Where(x => x.Id == id).FirstOrDefault();
            if (value is null)
            {
                return Ok("Not found");
            }

            value.KitapAdi = kitap.KitapAdi;
            value.Yazari = kitap.Yazari;
            value.KitapSeriNo = kitap.KitapSeriNo;
            return Ok(booklist);
        }

        [HttpDelete] //Silme
        public IActionResult Delete(int id)
        {
            var value = booklist.Where(x => x.Id == id).FirstOrDefault();
            if (value is null)
            {
                return NotFound();
            }

            booklist.Remove(value);
            return Ok(booklist);
        }

    }
}
