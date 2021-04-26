
//namespace VismaBookLibrary
//{
//    class Book
//    {

//        private string _iSBN;
//        public string ISBN { get => _iSBN; private set
//            {
//                Regex regex = new Regex(@"^[0-9]{13}$");
//                if (regex.IsMatch(value.ToString()))
//                {
//                    _iSBN = value;
//                } else
//                {
//                    Console.WriteLine("Please ensure that the ISBN number supplied is correct. /t The current standard is 13 digits in length. To convert ISBNS of old titles to it, please use the ISBN calculator at https://www.isbn-international.org");
//                }
//            }

//        }

//        private string _publicationDate;
//        public string PublicationDate
//        {
//            get => _publicationDate; private set
//            {
//                Regex regex = new Regex(@"^[0-9]{4}$");
//                if (regex.IsMatch(value.ToString()))
//                {
//                    _publicationDate = value;
//                } else
//                {
//                    Console.WriteLine("Please ensure that the date of publication is correct. /t Accepted format: YYYY.");
//                }
//            }

//        }

//      
