//using Moq;
//using Parking.Application.Dtos;
//using Parking.Application.Interfaces;

//namespace Test
//{
//    public class ParkingTest
//    {
//        private IParkingService _parkingService;
//        private Dictionary<int, VehicleEntryDto> _vehicles;

//        [SetUp]
//        public void Setup()
//        {
//            var mockParkingService = new Mock<IParkingService>();
//            _parkingService = mockParkingService.Object;

//            SetVehicles();
//        }

//        private void SetVehicles()
//        {
//            _vehicles = new Dictionary<int, VehicleEntryDto>
//            {
//                { 1, new VehicleEntryDto("MJX-1640", (new DateTime(2024, 8, 17, 19, 59, 46).ToString())) },
//                { 2, new VehicleEntryDto("MJX-1640", new DateTime(2024, 8, 15, 9, 22, 15).ToString()) }
//            };
//        }

//        [Test]
//        public void EntryTest()
//        {
//            var result1 = _parkingService.SetNewEntry(_vehicles[1]);
//            var result2 = _parkingService.SetNewEntry(_vehicles[2]);

//            var vehicles = _parkingService.GetAllVehicles().ToArray();

//            var vehicleAdded1 = vehicles[0];
//            Assert.IsTrue(result1);
//            Assert.Equals(_vehicles[1].Plate, vehicleAdded1.Plate);
//            Assert.Equals(_vehicles[1].EntryDate.ToString(), vehicleAdded1.EntryDate);
//            Assert.IsNull(vehicleAdded1.DepartureDate);

//            var vehicleAdded2 = vehicles[1];
//            Assert.IsTrue(result2);
//            Assert.Equals(_vehicles[2].Plate, vehicleAdded2.Plate);
//            Assert.Equals(_vehicles[2].EntryDate.ToString(), vehicleAdded2.EntryDate);
//            Assert.IsNull(vehicleAdded2.DepartureDate);
//        }

//        [Test]
//        public void DepartureDto()
//        {

//        }
//    }
//}