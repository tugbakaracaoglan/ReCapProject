using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        //const method yaz: ctor tabtab
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {

                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=300,ModelYear=2018,Description="BMW"},
                new Car{Id=2,BrandId=1,ColorId=2,DailyPrice=250,ModelYear=2015,Description="Mercedes"},
                new Car{Id=3,BrandId=2,ColorId=3,DailyPrice=420,ModelYear=2020,Description="Seat"},
                new Car{Id=4,BrandId=3,ColorId=3,DailyPrice=380,ModelYear=2019,Description="Hyundai"},
                new Car{Id=5,BrandId=4,ColorId=1,DailyPrice=270,ModelYear=2018,Description="Audi"}

                };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        Car CarToDelete;
        public void Delete(Car car)
        {
            CarToDelete = _cars.Where(p => p.Id == car.Id).FirstOrDefault();
            _cars.Remove(CarToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            //where yaz hata verince ampulden
            return _cars.Where(p => p.Id == id).FirstOrDefault();
        }

        Car CarToUpdate;
        public void Update(Car car)
        {
            CarToUpdate= _cars.Where(p => p.Id == car.Id).FirstOrDefault();
            car.BrandId = CarToUpdate.BrandId;
            car.ColorId = CarToUpdate.ColorId;
            car.DailyPrice = CarToUpdate.DailyPrice;
            car.Description = CarToUpdate.Description;
            car.ModelYear = CarToUpdate.ModelYear;

        }
    }
}
