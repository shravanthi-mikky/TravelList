app.controller("DashboardCtrl", function ($scope, $http, $uibModal, $window, $location) {
  $scope.tableView = [0];
  let headersConfig = {
    headers: {
      Authorization: "Bearer " + localStorage.getItem("token")
    }
  }

  //Get all Lists

  $scope.getAllEmployees = function () {
    $http.get("https://localhost:44386/api/Travel/AllLists", headersConfig)
      .then((response1) => {
        console.log(response1.data);
        $scope.AllEmployeesArray = response1.data;
        /*const merged = $scope.AllEmployeesArray.concat($scope.AllPayDetailsArray); 
      console.log(merged)*/

      }, (error) => {
        console.log(error)
      })
  }

  $scope.getAllPayDetails = function () {
    $http.get("https://localhost:44386/api/User/GetPayDetails", null)
      .then((response1) => {
        console.log(response1.data.response);
        $scope.AllPayDetailsArray = response1.data.response;
      }, (error) => {
        console.log(error)
      })
  }

  $scope.PaymentTheBill = function (listId) {
    listId = $window.localStorage.listId;
    
    $location.path("/pay");
  }

  $scope.GetSingleValue = function (listId) {
  
    $http.get(`https://localhost:44386/api/User/GetSingleValue?listId=${listId}`, null)
      .then((response) => {
        console.log(response);
        $scope.Value = response.data.response;
        console.log($scope.Value[0].result);
        document.getElementById('SinglePayValue').innerHTML = $scope.Value[0].result;
      }, (error) => {
        console.log(error)
      })


  }

  //Add Employee
  $scope.AddEmploy = function (place, startDate, endDate, duration, cost, members) {
    var data = {
      place: place,
      startDate: startDate,
      endDate: endDate,
      duration: duration,
      cost: cost,
      members: members
    }
    $http.post("https://localhost:44386/api/Travel/AddList", JSON.stringify(data), headersConfig)
      .then((response1) => {
        console.log(response1);
        if (response1) {
          $location.path('/Dashboard');
        }

      }, (error) => {
        console.log(error)
      })
  }

  //Delete list
  $scope.DeleteEmploy = function (listId) {
    $scope.listId = listId;
    console.log($scope.listId);
    $http.delete(`https://localhost:44386/api/Travel/RemoveList?empid=${listId}`)
      .then((response1) => {
        console.log(response1);
        if (response1) {
          console.log(response1);
          window.location.reload();
        }
      }, (error) => {
        console.log(error)
      })
  }
  //Update
  $scope.UpdateEmploy = function (listId, place, startDate, endDate, duration, cost, members) {
    var data = {
      listId: listId,
      place: place,
      startDate: startDate,
      endDate: endDate,
      duration: duration,
      cost: cost,
      members: members
    }
    $http.put(`https://localhost:44386/api/Travel/UpdateList?ListId=${listId}`, JSON.stringify(data))
      .then((response1) => {
        console.log(response1);
        if (response1) {
          SingleTour = response1.data.response;
          console.log("Single Tour");
          console.log(SingleTour);
          $location.path('/Dashboard');
        }

      }, (error) => {
        console.log(error)
      }
      )
  };

  // edit modal 
  $scope.editmodal = function (listId, place, startDate, endDate, duration, cost, members) {
    user = {
      listId: listId,
      place: place,
      startDate: startDate,
      endDate: endDate,
      duration: duration,
      cost: cost,
      members: members
    }

    $scope.modalInstance = $uibModal.open({
      ariaLabelledBy: 'modal-title',
      ariaDescribedBy: 'modal-body',
      templateUrl: 'Components/Dashboard/EditPage.html',
      controller: 'empeditController',
      controllerAs: '$ctrl',
      size: 'md',
      resolve: {
        user: function () {
          return user;
        }
      }
    });
  }

  // Invoice modal 
  $scope.Invoicemodal = function (listId, place) {
    user = {
      listId: listId,
      place: place
    }
    $window.localStorage.setItem('listId', user.listId);
    $window.localStorage.setItem('place', user.place);

    console.log($window.localStorage.listId);
    console.log($window.localStorage.place);
    $scope.GetMembers()
    $scope.modalInstance = $uibModal.open({
      ariaLabelledBy: 'modal-title',
      ariaDescribedBy: 'modal-body',
      templateUrl: 'Components/Invoice/Invoice.html',
      controller: 'empInvoiceController',
      controllerAs: '$ctrl',
      size: 'md',
      resolve: {
        user: function () {
          return user;
        }
      }
    });
  }

  //Get Members

  $scope.GetMembers = function () {

    /* var data={
      listId:$window.localStorage.listId,
      place:$window.localStorage.place
    } */
    $http.get(`https://localhost:44386/api/Member/GetMembersById?ListId=${$window.localStorage.listId}&place=${$window.localStorage.place}`, null)
      .then((response1) => {
        console.log(response1);
        if (response1) {
          $scope.tableView = [1];
          $scope.MembersArray = response1.data.response;
          console.log($scope.MembersArray);
        }

      }, (error) => {
        console.log(error)
      }
      )
  };


  // New method to move to Invoice page

  $scope.Redirect = function (listId, place, cost) {
    user = {
      listId: listId,
      place: place,
      cost: cost
    }
    $window.localStorage.setItem('listId', user.listId);
    $window.localStorage.setItem('place', user.place);
    $window.localStorage.setItem('cost', user.cost);

    console.log($window.localStorage.listId);
    console.log($window.localStorage.place);
    console.log($window.localStorage.cost);

    $location.path("/Invoice");
  }
  $scope.ReturnToHome = function () {
    $location.path("/Dashboard");
  }

  // Export as pdf

  $scope.ExportAsPdf = function () {
    html2canvas(document.getElementById('tblCustomer'), {
      onrendered: function (canvas) {
        var data = canvas.toDataURL();
        var docDefinition = {
          content: [{
            image: data,
            width: 500
          }]
        };
        pdfMake.createPdf(docDefinition).download("Table.pdf");
      }
    });
  }
});

// Edit controller

app.controller("empeditController", function ($scope, $uibModalInstance, $window, $location) {
  $scope.listId = user.listId;
  $scope.place = user.place;
  $scope.startDate = user.startDate;
  $scope.endDate = user.endDate;
  $scope.duration = user.duration;
  $scope.cost = user.cost;
  $scope.members = user.members;
  $scope.cancelModal = function () {
    console.log("cancelmodal");
    $uibModalInstance.dismiss('close');
  }
  $scope.ok = function () {
    $window.$location.reload();
    $uibModalInstance.close('save');
  }



  $scope.GetMembers = function (listId, place) {

    var data = {
      listId: listId,
      place: place
    }
    $http.get(`https://localhost:44386/api/Member/GetMembersById?ListId=${listId}&place=${place}`, JSON.stringify(data))
      .then((response1) => {
        console.log(response1);
        if (response1) {
          $scope.tableView = [1];
          $scope.MembersArray = response1.data.response;
          console.log($scope.MembersArray);
        }

      }, (error) => {
        console.log(error)
      }
      )
  };

});