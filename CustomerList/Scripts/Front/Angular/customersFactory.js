angular
    .module("customersList")
    .factory("CustomersFactory", function($http)
{
        function getPersons() {
            //return $http.get("../Content/data.json");
            return $http.get("/API/Customers");
        }

        return {
            getPersons: getPersons
        }
});


