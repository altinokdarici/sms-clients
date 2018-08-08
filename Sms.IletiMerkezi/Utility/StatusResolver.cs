using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.IletiMerkezi.Utility
{
    internal class StatusResolver
    {
        public static readonly Dictionary<int, string> Status = new Dictionary<int, string>()
        {
            {110,"Mesaj gönderiliyor" },
            {111,"Mesaj gönderildi" },
            {112,"Mesaj gönderilemedi" },
            {113,"Siparişin gönderimi devam ediyor" },
            {114,"Siparişin gönderimi tamamlandı" },
            {115,"Sipariş gönderilemedi"},
            {200,"İşlem başarılı"},
            {400,"İstek çözümlenemedi"},
            {401,"Üyelik bilgileri hatalı"},
            {402,"Bakiye yetersiz"},
            {404,"API istek yapılan yönteme sahip değil"},
            {450,"Gönderilen başlık kullanıma uygun değil"},
            {451,"Tekrar eden sipariş"},
            {452,"Mesaj alıcıları hatalı"},
            {453,"Sipariş boyutu aşıldı"},
            {454,"Mesaj metni boş"},
            {455,"Sipariş bulunamadı"},
            {456,"Sipariş gönderim tarihi henüz gelmedi"},
            {457,"Mesaj gönderim tarihinin formatı hatalı"},
            {503,"Sunucu geçici olarak servis dışı"}
        };

        public static bool IsSuccess(int statusCode)
        {
            switch (statusCode)
            {
                case 110:
                case 111:
                case 200:
                    return true;
                default:
                    return false;
            }
        }
        public static string GetDescription(int statusCode) => Status[statusCode];


    }
}
