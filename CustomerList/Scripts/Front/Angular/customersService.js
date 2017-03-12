angular
    .module('customersList')
    .service('CustomersService', function () {


        function addPerson(person) {
            console.log("Add person!");
        }

        var personsList = [
            {
                "name": "Waintig for data...",
                "email": "...",
                "birthdate": "2000-00-00T00:00:00-00:00",
                "phonenumber": "...",
                "address": "...",
                "city": "...",
                "country": "..."
            }
        ];

        var selectedPerson = null;

        return {
            selectedPerson: selectedPerson,
            addPerson: addPerson,
            persons: personsList
        }
    });