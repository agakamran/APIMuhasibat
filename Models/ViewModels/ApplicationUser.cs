
using Microsoft.AspNetCore.Identity;
using APIMuhasibat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIMuhasibat.Models.ViewModels
{
   public class ApplicationUser : IdentityUser
    {
        string _FirstName = null;
        string _LastName = null;
        Nullable<long> _providerId = null;
        Nullable<long> _providername = null;
        string _photoUrl = null;
        string _IP = null;
       // decimal _percent = 0;
        List<RefreshToken> _refreshTokens = null;
        public string FirstName
        {
            get { return _FirstName; }
            set { if (value != null) { _FirstName = value; } }
        }
        public string LastName
        {
            get { return _LastName; }
            set { if (value != null) { _LastName = value; } }
        }
        public long? providerId
        {
            get { return _providerId; }
            set { if (value != null) { _providerId = value; } }
        }
        public long? providername
        {
            get { return _providername; }
            set { if (value != null) { _providername = value; } }
        }
        public string photoUrl
        {
            get { return _photoUrl; }
            set { if (value != null) { _photoUrl = value; } }
        }
        public string IP
        {
            get { return _IP; }
            set { if (value != null) { _IP = value; } }
        }
        //public decimal percent
        //{
        //    get { return _percent; }
        //    set { if (value > 0) { _percent = value; } }
        //}
        [JsonIgnore]
        public List<RefreshToken> RefreshTokens
        {
            get { return _refreshTokens; }
            set { if (value != null) { _refreshTokens = value; } }
        }
        // public string MacAdd { get; set; }
        // public bool Hal { get; set; }
        // public decimal Mebleg { get; set; }
        //----------------------------------
        //public string fio { get; set; }       
        //public string vesige { get; set; }
        //public string telefon { get; set; }
        //public string MachineName { get; set; }
        //public string komuser { get; set; }
    }
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName)
        { }
        public bool create { get; set; }
        public bool reade { get; set; }
        public bool update { get; set; }
        public bool delete { get; set; }
    }
    [Table("Navbars")]
   public class Navbar
    {
        string _nid = null, _pid = null, _ntitle = null, _npath = null,_nlan = null, _nrol = null, _nicon = null;
        int _ncsay = 0, _ink = 0; bool _nisparent = false;
        [Key]
        [Required(AllowEmptyStrings = true), MaxLength(36)]
        public string nid
        {
            get { return _nid; }
            set { if (value != null) { _nid = value; } }
        }
        [MaxLength(36)]
        public string pid
        {
            get { return _pid; }
            set { if (value != null) { _pid = value; } }
        }
        [MaxLength(150)]
        public string ntitle
        {
            get { return _ntitle; }
            set { if (value != null) { _ntitle = value; } }
        }
        [MaxLength(150)]
        public string npath
        {
            get { return _npath; }
            set { if (value != null) { _npath = value; } }
        }
        [MaxLength(50)]
        public string nicon
        {
            get { return _nicon; }
            set { if (value != null) { _nicon = value; } }
        }
        [MaxLength(2)]
        public string nlan
        {
            get { return _nlan; }
            set { if (value != null) { _nlan = value; } }
        }
        public int ncsay
        {
            get { return _ncsay; }
            set { if (value > 0) { _ncsay = value; } }
        }
        [MaxLength(36)]
        public string nrol
        {
            get { return _nrol; }
            set { if (value != null) { _nrol = value; } }
        }
        public int ink
        {
            get { return _ink; }
            set { if (value > 0) { _ink = value; } }
        }
        public bool nisparent
        {
            get { return _nisparent; }
            set { if (value != false) { _nisparent = value; } }
        }
    }
    [Table("Navroles")]
   public  class NavbarRole
    {
        string _nrid = null, _nid = null, _RoleId = null;
        [Key]
        [Required(AllowEmptyStrings = true), MaxLength(36)]
        public string nrid
        {
            get { return _nrid; }
            set { if (value != null) { _nrid = value; } }
        }
        [MaxLength(36)]
        public string nid
        {
            get { return _nid; }
            set { if (value != null) { _nid = value; } }
        }
        [MaxLength(36)]
        public string RoleId
        {
            get { return _RoleId; }
            set { if (value != null) { _RoleId = value; } }
        }
    }
    //[Table("stores")] //Магазин  firmas
    //class store
    //{
    //    string _storId = null;
    //    string _storname = null;
    //    string _storadress = null;
    //    string _storphone = null;
    //    string _storemail = null;
    //    decimal _storpercent = 0;
    //    string _userId = null;
    //    string _storvoen = null;
    //    Nullable<DateTime> _modifiedDate = null;
    //    public store() { }
    //    [Key]
    //    [Required(AllowEmptyStrings = true), MaxLength(36)]
    //    public string storId
    //    {
    //        get { return _storId; }
    //        set { if (_storId != null) { _storId = value; } }
    //    }
    //    [Required, MaxLength(50)]
    //    public string storname
    //    {
    //        get { return _storname; }
    //        set { if (_storname != null) { _storname = value; } }
    //    }
    //    [MaxLength(150)]
    //    public string storadress
    //    {
    //        get { return _storadress; }
    //        set { if (_storadress != null) { _storadress = value; } }
    //    }
    //    [MaxLength(20)]
    //    public string storphone
    //    {
    //        get { return _storphone; }
    //        set { if (_storphone != null) { _storphone = value; } }
    //    }
    //    [Required, MaxLength(50)]
    //    public string storemail
    //    {
    //        get { return _storemail; }
    //        set { if (_storemail != null) { _storemail = value; } }
    //    }
    //    [Required, MaxLength(36)]
    //    public string userId
    //    {
    //        get { return _userId; }
    //        set { if (_userId != null) { _userId = value; } }
    //    }
    //    public decimal storpercent
    //    {
    //        get { return _storpercent; }
    //        set { if (_storpercent > 0) { _storpercent = value; } }
    //    }
    //    public string storvoen
    //    {
    //        get { return _storvoen; }
    //        set { if (_storvoen != null) { _storvoen = value; } }
    //    }
    //    public Nullable<DateTime> ModifiedDate
    //    {
    //        get { return _modifiedDate; }
    //        set { if (_modifiedDate != null) { _modifiedDate = DateTime.Now; } }
    //    }
    //}
    /*[Table("pages")]
    public class page
    {
        [Key]
        [Required(AllowEmptyStrings = true), MaxLength(36)]
        public string cid { get; set; }
        [MaxLength(50)]
        public string csubject { get; set; }
        [MaxLength(50)]
        public string charda { get; set; }
        [MaxLength(2)]
        public string clan { get; set; }
        public int csira { get; set; }
        [MaxLength(150)]
        public string cheader { get; set; }
        public string ctex { get; set; }
        public float cpris { get; set; }
        [MaxLength(50)]
        public string cbuton { get; set; }
        [MaxLength(36)]
        public string nid { get; set; }
        public virtual Navbar navbars { get; set; }
        [MaxLength(36)]
        public string vid { get; set; }
        public virtual vido vidos { get; set; }
        public DateTime ctarix { get; set; }
    }
    [Table("vidos")]
    public class vido
    {
        [Key]
        [Required(AllowEmptyStrings = true), MaxLength(36)]
        public string vid { get; set; }
        public Byte[] vidio { get; set; }
        [MaxLength(150)]
        public string url { get; set; }
    }
    [Table("conts")]
    public class Cont
    {
        [Key]
        [Required(AllowEmptyStrings = true), MaxLength(36)]
        public string cid { get; set; }
        [MaxLength(36)]
        public string userId { get; set; }
        [StringLength(150)]
        public string yourname { get; set; }
        [StringLength(250)]
        public string subject { get; set; }
        public string message { get; set; }
        // [StringLength(10)]
        public DateTime tarix { get; set; }
        public bool isdelete { get; set; }
    }*/
    /* public class Menu
      {
          List<Menu> MenuList;
          public int MenuId { get; set; }
          public string MenuName { get; set; }
          public string MenuHref { get; set; }
          public List<Menu> GetMenu(int id)
          {
              MenuList = new List<Menu>();
              if (id == 1)
              {
                  MenuList.Add(new Menu() { MenuId = 1, MenuName = "Add Employee", MenuHref = "#" });
                  MenuList.Add(new Menu() { MenuId = 2, MenuName = "View Employee", MenuHref = "#" });
                  MenuList.Add(new Menu() { MenuId = 3, MenuName = "Delete Employee", MenuHref = "#" });
                  MenuList.Add(new Menu() { MenuId = 4, MenuName = "Edit Employee", MenuHref = "#" });
                  MenuList.Add(new Menu() { MenuId = 5, MenuName = "Logout", MenuHref = "#" });
              }
              else
              {
                  MenuList.Add(new Menu() { MenuId = 1, MenuName = "Edit Details", MenuHref = "#" });
                  MenuList.Add(new Menu() { MenuId = 2, MenuName = "My Task", MenuHref = "#" });
                  MenuList.Add(new Menu() { MenuId = 3, MenuName = "Contact Us", MenuHref = "#" });
                  MenuList.Add(new Menu() { MenuId = 4, MenuName = "Logout", MenuHref = "#" });
              }
              return MenuList;
          }
      }*/
    /* public List<Navbar> GetMenu(string id)
       {
           NavbarList = new List<Navbar>();
         //  if (id == "admin")
          // {

         //  }
         //  else
         //  {
               NavbarList.Add(new Navbar() { navid = "1", parentid = "0", title = "Ana Səhvə", path = "/", icon = "" });
               NavbarList.Add(new Navbar() { navid = "2", parentid = "0", title = "Обучающие Курсы", path = "lessin/courses", icon = "" });
               NavbarList.Add(new Navbar() { navid = "3", parentid = "0", title = "LESSONS", path = "lessin/lessons", icon = "" });
               NavbarList.Add(new Navbar() { navid = "4", parentid = "0", title = "TESTIMONIALS", path = "lessin/testimonials", icon = "" });
               NavbarList.Add(new Navbar() { navid = "5", parentid = "0", title = "BLOG", path = "lessin/blog", icon = "" });
               NavbarList.Add(new Navbar() { navid = "6", parentid = "0", title = "ABOUT", path = "lessin/about", icon = "" });
               NavbarList.Add(new Navbar() { navid = "7", parentid = "0", title = "CONTACT", path = "lessin/contact", icon = "" });

               NavbarList.Add(new Navbar() { navid = "8", parentid = "0", title = "Adminstrator", path = "admins", icon = "" });
               NavbarList.Add(new Navbar() { navid = "9", parentid = "8", title = "ADMIN", path = "admins/admin", icon = "" });
               NavbarList.Add(new Navbar() { navid = "10", parentid = "8", title = "ROLES", path = "admins/role", icon = "" });
               NavbarList.Add(new Navbar() { navid = "11", parentid = "8", title = "Add CART", path = "admins/cartlar", icon = "" });
               NavbarList.Add(new Navbar() { navid = "12", parentid = "8", title = "Add VIDEO", path = "admins/addvideo", icon = "" });
               NavbarList.Add(new Navbar() { navid = "13", parentid = "8", title = "Add PAGE", path = "admins/addpage", icon = "" });
           //}
           return NavbarList;
       }*/



    /*public class ApplicationUser : IdentityUser
   {
       public string CustomTag { get; set; }
       public string CustomTagBis { get; set; }
   }
   public class Teacher : ApplicationUser
   {
       public string TeacherIdentificationNumber { get; set; }
       public ICollection<Course> Courses { get; set; }
   }
   public class Student : ApplicationUser
   {
       public ICollection<StudentGroup> Groups { get; set; }
   }
   public class Parent : ApplicationUser
   {
       public ICollection<Student> Children { get; set; }
   }
   public class Course
   {
       public int Id { get; set; }
       public string Title { get; set; }
       public string Category { get; set; }
   }
   public class StudentGroup
   {
       public int Id { get; set; }
       public string Name { get; set; }
   }*/
}
