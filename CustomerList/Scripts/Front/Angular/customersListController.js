angular
    .module("customersList")
    .controller("CustomerListController", function(
        $scope,
        CustomersService,
        CustomersFactory
    )
    {
        $scope.search = "";
        $scope.order = "name";
        $scope.contacts = CustomersService;

        CustomersFactory.getPersons()
            .then(function (data) {
                $scope.contacts.persons = data.data;

            }, function (error) {
                console.log(error)
    })
    });