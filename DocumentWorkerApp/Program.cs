using System;

namespace DocumentWorkerApp
{
    class DocumentWorker
    {
        public virtual void OpenDocument()
        {
            Console.WriteLine("Документ открыт");
        }
        public virtual void EditDocument()
        {
            Console.WriteLine("Редактирование документа доступно в версии Про");
        }
        public virtual void SaveDocument()
        {
            Console.WriteLine("Сохранение документа доступно в версии Про");
        }
    }
    class ProDocumentWorker : DocumentWorker
    {
        public override void EditDocument()
        {
            Console.WriteLine("Документ отредактирован");
        }
        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Эксперт");
        }
    }
    class ExpertDocumentWorker : ProDocumentWorker
    {
        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в новом формате");
        }
    }
    class Program
    {
        private const string PRO_LICENSE = "333";
        private const string EXP_LICENSE = "555";
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ключ (если хотите выбрать Про версию то нужно вводить: 333, а если Эксперт версию то нужно вводить: 555, для бесплатной версии не надо вводить ключ):");
            var license = Console.ReadLine();
            DocumentWorker worker;
            switch (license)
            {
                case PRO_LICENSE: worker = new ProDocumentWorker(); break;
                case EXP_LICENSE: worker = new ExpertDocumentWorker(); break;
                default: worker = new DocumentWorker(); break;
            }
            while (true)
            {
                Console.WriteLine("Выберите команду: o - Открыть документ ");
                Console.WriteLine("                  e - Редактировать документ ");
                Console.WriteLine("                  s - Сохранить документ ");
                Console.WriteLine("                  q - Выйти ");
                switch (Console.ReadLine())
                {
                    case "o": worker.OpenDocument(); break;
                    case "e": worker.EditDocument(); break;
                    case "s": worker.SaveDocument(); break;
                    case "q": return;
                }
            }
        }
    }
}