import { Component } from '@angular/core';
import { NgSelectOption } from '@angular/forms';
import { OrderRequest } from 'src/models/order.request';
import { OrderResponse } from 'src/models/order.response';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'GFT-Front';

  times = [{id: 1, name:"Morning"}, {id:2, name:"Night"}];
  selectedValue = "Select a time";
  number = "";
  public time: any;
  order: any;
  pastOrders: string[] = [];
  constructor(private apiService: ApiService){}

  requestOrder(){    
    var orderList = this.convertOrderToArray(this.number);
    var request = new OrderRequest({ time: this.time, orderList: orderList});

    var OutputValue = document.getElementById("OutputValue");
    while(OutputValue?.firstChild)OutputValue.removeChild(OutputValue.firstChild);
    
    this.apiService.requestOrder(request).subscribe((res: OrderResponse) => {
      if(res){
        this.order = res.order;
        this.pastOrders.push(this.order);
        OutputValue?.appendChild(document.createTextNode(res.order?? ""));
      };
      this.time = "";
      this.number = "";
      
    }, (err) => {alert("Error when trying to send request, please validate data")});
  }

  convertOrderToArray(orders: any) : number[]{
    var reg = new RegExp('^[0-9]*$');
    var match = orders.split(',');
    var orderArray: number[] = [];
    match.forEach((element: any) => {
      if(reg.test(element) == false){
        alert("It is not a number: " + element);
      }else{
        orderArray.push(element);
      };
    });
    return orderArray;
  }
}
