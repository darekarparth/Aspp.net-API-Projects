﻿
function Item(id, name, price, quantity) {
    const self = this;
    self.Id = ko.observable(id);
    self.Name = ko.observable(name);
    self.Price = ko.observable(price);
    self.Quantity=ko.observable(quantity)
};

//function CartItem(cartId, id)
//{
//    const self = this;
//    self.CartId = ko.observable(cartId);
//    self.Id = ko.observable(id);

//}

function viewModel() {
    const self = this;
  

    self.items = ko.observableArray([]);
    self.cartitems = ko.observableArray([]);
    self.cart = ko.observable();



   // GetCart();//Call the Function which gets all records using ajax call 
   
   // function GetProducts() {
        $.ajax({
            type: "GET",
            url: "/api/products",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                var Data = ko.utils.arrayMap(data, function (item) {
                    return new Item(item.id, item.name, item.price, item.quantity);
                });
            
                self.items(Data);
              },
            error: function (error) {
                alert(error.status + "<--and--> " + error.statusText);
            }
        });
  //  }


     self.AddTOCart = function (Product) { //from this Product we recieve that data which is binded to particular item or product in array.
      $.ajax({
            type: "POST",
            url: "/api/cart",
            data: ko.toJSON(Product), //Convert the Observable Data into JSON
            contentType: "application/json",
            success: function (data) {
                alert("Record Added Successfully");

          },
            error: function () {
                alert("Failed");
            }
        });
        //Ends Here
    };


    GetCart();
    function GetCart() {
        $.ajax({
            type: "GET",
            url: "/api/cart",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                self.cartitems(data)
            },
        
             error: function (error) {
                alert(error.status + "<--and--> " + error.statusText);
            }
        });

    }

        
  


    //self.update = function () {
    //    var Data1 = new CartItem(this.CartId(), this.Id(), this.Name(), this.Price(), this.Quantity())
    //    //var Data2 =
    //    //{
    //    //    CartId:Data1.CartId(),
    //    //    Id:Data1.Id(),
    //    //    Name: Data1.Name(),
    //    //    Price: (Data1.Price() * Data1.Quantity()),
    //    //    Quantity: Data1.Quantity()
    //    //}
      
    //    $.ajax({
    //        type: "PUT",
    //        url: "/api/cart/" + Data1.CartId(),
    //        data: ko.toJSON(Data1), // data: ko.toJSON(Data2),
    //        contentType: "application/json",
    //        success: function (data) {
    //            alert("Record Updated Successfully");
    //           // GetCustomers();
    //        },
    //        error: function (error) {
    //            alert(error.status + "<!----!>" + error.statusText);
    //        } 
    //    });
    //}; 


     self.DelProduct = function (Product) {
       // var Data1 = new CartItem(this.CartId(), this.Id(), this.Name(), this.Price(), this.Quantity())
        //var Data2 = {
        //    CartId:Data1.CartId,
        //    Id: Data1.Id,
        //    Name: Data1.Name,
        //    Price: Data1.Price
        //}

        $.ajax({
            type: "DELETE",
            url: "api/cart/" + Product.CartId,//Data2.CartId
            success: function (data) {
                alert("Record Deleted Successfully");
                // GetCart()//Refresh the Table  
               // self.items2.remove(data)
            },
            error: function (error) {
                alert(error.status + "<--and--> " + error.statusText);
            }
        });
    }; 
};
    
$(document).ready(function () {
    ko.applyBindings(new viewModel());
});