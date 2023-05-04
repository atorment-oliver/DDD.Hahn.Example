import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Customer } from '../models/customer';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http:HttpClient) { }

  url:string = "http://localhost:32775/Customer";

  getCustomer(){
    return this.http.get(this.url);
  }

  addCustomer(customer:Customer):Observable<Customer>{
    return this.http.post<Customer>(this.url, customer);
  }

  updateCustomer(id:String, customer:Customer):Observable<Customer>{
    return this.http.put<Customer>(this.url + `/${id}`, customer);
  }

  deleteCustomer(id:String){
    return this.http.delete(this.url + `/${id}`);
  }
}
