# IFDV

The design is based on the idea that a rental is a begin date, an end date, a price and a running status. This is modelled with the IRental interface. I didn't add a Bike to it because it was of no use to the exercise, and because it could also be placed in some other class that agreggates the rental and the bike.

The family rental is a kind-of composite pattern. The inner rentals are instances of SingleRental and not IRental because I assumed a family rental composed of other family rentals made no sense. Adjusting FamilyRental to work with nested FamilyRentals requires just changing the type declaration.

Some things like Internationalization were left out because I run out of time.

The project is just a standard Visual Studio solution with a class library and a test project.


