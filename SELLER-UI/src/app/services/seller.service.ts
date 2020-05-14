import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Seller } from '../Models/seller';
const Requestheaders={headers:new HttpHeaders({
  'Content-Type':'application/json',
  'Authorization':'Bearer'+localStorage.getItem('token')
})}

@Injectable({
  providedIn: 'root'
})
export class SellerService {
  url1:string='http://localhost:62069/Seller/'
  constructor(private http:HttpClient) { }

  public ViewSellerProfile(sellerid:number):Observable<Seller>
   {
     return this.http.get<Seller>(this.url1+'Profile/'+sellerid,Requestheaders)
   }
   public EditSellerProfile(seller:Seller):Observable<Seller>
   {
     return this.http.put<Seller>(this.url1+'EditProfile/',seller)
   }
}
