app.controller("InvoiceController", function ($scope, $window, $location, $http) {

    $scope.GetMembers = function () {
        $http.get(`https://localhost:44386/api/Member/GetMembersById?ListId=${$window.localStorage.listId}&place=${$window.localStorage.place}`, null)
            .then((response1) => {
                console.log(response1);
                if (response1) {
                    $scope.MembersArray = response1.data.response;
                    console.log($scope.MembersArray);
                    document.getElementById("demo").innerHTML = localStorage.getItem("cost");
                }

            }, (error) => {
                console.log(error)
            }
        )
    };

    //Payment Method
    $scope.PaymentDone=function (cardHolder,cardNumber,expiryDate,cvv,result){
        var data={
            cardHolder:cardHolder,
            cardNumber:cardNumber,
            expiryDate:expiryDate,
            cvv:cvv
          }

          var data2 ={
            listId:Number($window.localStorage.listId),
            result:"Paid"
          }
        $http.post("https://localhost:44386/api/User/PayCheck",JSON.stringify(data))
        .then((response)=>{
            if(response){
                console.log(response);
                $http.put("https://localhost:44386/api/User/UpdatePay",JSON.stringify(data2))
                .then((response)=>{
             if(response){
                console.log(response);
            }
        })
                $location.path("/Sample");

            }
        })


    }
    
    $scope.MakePayment=function (){
        listId=$window.localStorage.listId;
        $location.path("/pay");
    }

    $scope.ReturnToHome=function (){
        $location.path("/Dashboard");
    }
    //Export as pdf

    $scope.ExportAsPdf = function () {

        html2canvas(document.getElementById('InvoiceDetails'), {
            onrendered: function (canvas) {
                var data = canvas.toDataURL();
                var docDefinition = {
                    content: [{
                        image: data,
                        width: 500
                    }]
                };
                pdfMake.createPdf(docDefinition).download("TravelInvoice.pdf");
                it('should check ng-class', function() {
                    expect(element(by.css('.base-class')).getAttribute('class')).not.
                      toMatch(/my-class/);
                  
                    element(by.id('setbtn')).click();
                  
                    expect(element(by.css('.base-class')).getAttribute('class')).
                      toMatch(/my-class/);
                  
                    element(by.id('clearbtn')).click();
                  
                    expect(element(by.css('.base-class')).getAttribute('class')).not.
                      toMatch(/my-class/);
                });  
            }
        });
    }
});