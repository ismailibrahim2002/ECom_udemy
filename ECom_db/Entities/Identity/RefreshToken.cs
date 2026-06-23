using System;
using System.Collections.Generic;
using System.Text;

namespace ECom_db.Entities.Identity
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = string.Empty; //يربط التوكن ده بمستخدم معين جوه جدول المستخدمين
        public string Token { get; set; } = string.Empty; // ده النص العشوائي المشفر (التوكن نفسه) اللي السيرفر بيولده وبيسيفه هنا، وبيبعت نسخة منه للـ .
    }
}
 