import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Items } from '../Models/items';
import { Observable } from 'rxjs';
const Requestheaders={headers:new HttpHeaders({
  'Content-Type':'application/json',
  'Authorization':'Bearer'+localStorage.getItem('token')
})}

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  url:string='http://localhost:62069/Item/'

  constructor(private http:HttpClient) { }
  public GetItem(itemid:number):Observable<Items>
  {
    return this.http.get<Items>(this.url+'GetItem/'+itemid,Requestheaders);
  }
  
  public AddItem(items:Items):Observable<any>
  {
    return this.http.post<any>(this.url+'AddItem',JSON.stringify(items),Requestheaders);
  }
  public DeleteItem(itemid:number):Observable<any>
  {
    return this.http.delete<any>(this.url+'DeleteItem/'+itemid,Requestheaders);
  }
  public UpdateItem(items:Items):Observable<any>
  {
    return this.http.put<any>(this.url+'UpdateItem',items,Requestheaders);
  }
  public ViewItems(sellerid:number):Observable<Items[]>
  {
    return this.http.get<Items[]>(this.url+'ViewItems/'+sellerid,Requestheaders);
  }
}
