using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Core.Entities.Concrete;
using TodoApp.Entities.Concrete;

namespace ToDoApp.Business.Constants
{
    public static class Messages
    {
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı!";

        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";

        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi.";

        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";

        public static string ErrorGetToDoById = "İlgili ID'ye göre yapılacak iş bulunamadı.";

        public static string ErrorGetToDoGroupById = "İlgili ID'ye göre herhangi bir yapılacaklar listesi bulunamadı.";

        public static string ErrorGetListTodoByUserId = "İlgili kullanıcıya ait yapılacak bulunamadı!";

        public static string ErrorGetListTodoByTodoGroupId = "İlgili grup id'sine göre yapılacaklar bulunamadı!";

        public static string ErrorGetToDoGroupByUserIDAndGroupId = "İlgili kullanıcı ID ve grup ID'sine göre yapılacaklar bulunamadı!";

        public static string ErrorGetListOperationClaim = "Metod izinleri listesi bulunamadı!";

        public static string ErrorGetListOperationClaimByUserId = "İlgili kullanıcıya ait metod izinleri listesi bulunamadı!";

        public static string ErrorAddNewOperationClaim = "Yeni metod izni eklenirken sorun oluştu!";

        public static string ErrorAddNewUserOperationClaim = "İlgili kullanıcıya yeni metod izni eklenirken sorun oluştu!";

        public static string ErrorAddNewToDo = "Yeni yapılacak iş oluşturulurken hata oluştu!";

        public static string ErrorAddNewToDoGroup = "Yeni yapılacak iş listesi oluşturulurken hata oluştu!";

        public static string ErrorAddNewToDoGroupElement = "Yapılacak iş, listeye aktarılırken hata oluştu!";

        public static string ErrorUpdateIsCompletedByToDoId = "Yapılacak işin tamamlanma bilgisi güncellenirken hata oluştu!";
    }
}
