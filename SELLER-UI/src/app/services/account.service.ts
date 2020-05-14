import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Seller } from '../Models/seller';
import { Observable } from 'rxjs';
const Requestheaders={headers:new HttpHeaders({
  'Content-Type':'application/json',
  'Authorization':'Bearer'+localStorage.getItem('token')
})}

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  url:string='http://localhost:62069/Account/'

  constructor(private http:HttpClient) { }
  
  public SellerRegister(seller:Seller):Observable<any>
  {
    return this.http.post<any>(this.url+'REGISTER-SELLER',seller);
  }
  
  public SellerLogin(username:string,password:string):Observable<any>
  {
    return this.http.get<any>(this.url+'SellerLogin/'+username+'/'+password,Requestheaders);
  }

 
}
