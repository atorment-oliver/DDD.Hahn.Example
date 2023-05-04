import { Component } from '@angular/core';
import { Customer } from './models/customer';
import { CustomerService } from './services/customer.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  customer:Customer = new Customer();
  datatable:any = [];

  constructor(private customerService:CustomerService){

  }

  ngOnInit(): void {
    this.onDataTable();
  }

  onDataTable(){
    this.customerService.getCustomer().subscribe(res => {
      this.datatable = res;
      console.log(res);
    });
  }

  onAddCustomer(customer:Customer):void{
    customer.id = "1";
    this.customerService.addCustomer(customer).subscribe(res => {
      if(res){
        alert(`The customer ${customer.name} registered successfully!`);
        this.clear();
        this.onDataTable();
      } else {
        alert('Error! :(')
      }
    });
  }

  onUpdateCustomer(customer:Customer):void{
    this.customerService.updateCustomer(customer.id, customer).subscribe(res => {
      if(res){
        alert(`The customer Id ${customer.id} was updated!`);
        this.clear();
        this.onDataTable();
      } else {
        alert('Error! :(')
      }
    });
  }

  onDeleteCustomer(id:String):void{
    this.customerService.deleteCustomer(id).subscribe(res => {
      if(res){
        alert(`The customer Id ${id} was deleted!`);
        this.clear();
        this.onDataTable();
      } else {
        alert('Error! :(')
      }
    });
  }

  onSetData(select:any){
    this.customer.id = select.id;
    this.customer.name = select.name;
    this.customer.email = select.email;
    this.customer.address = select.address;
  }

  clear(){
    this.customer.id ="";
    this.customer.name = "";
    this.customer.email = "";
    this.customer.address = "";
  }
}
