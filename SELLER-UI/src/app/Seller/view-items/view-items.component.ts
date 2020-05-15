import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Items } from 'src/app/Models/items';
import { Seller } from 'src/app/Models/seller';
import { ItemService } from 'src/app/services/item.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-items',
  templateUrl: './view-items.component.html',
  styleUrls: ['./view-items.component.css']
})
export class ViewItemsComponent implements OnInit {
  itemForm:FormGroup;
  submitted=false;
  list:Items[];
  item:Items;
  seller:Seller;
  list1:Items;
  item1:Items
  constructor(private builder:FormBuilder,private service:ItemService,private route:Router) {
    this.item=JSON.parse(localStorage.getItem('item'));
    //this.list1.push(this.item)
  //console.log(this.item);
  //console.log(this.item.id);
    let sellerid=Number(localStorage.getItem('Sellerid'))
    this.service.ViewItems(sellerid).subscribe(res=>{
      this.list=res;
      console.log(this.list);
    },err=>{
      console.log(err)
    })
   }
   ngOnInit() {
    this.itemForm=this.builder.group({
        itemid:[''],
       itemname:[''],
        price:[''],
        stockno:[''],
        description:[''],
        remarks:[''],
        imagename:[''],
        sellerid:['']
    });
  }
  get f() { return this.itemForm.controls; }

  onSubmit() {
      this.submitted = true;
  }
  onReset() {
      this.submitted = false;
      this.itemForm.reset();
  }
  Update()
  {
  this.item1=new Items();
  this.item1.itemid=Number(this.itemForm.value["itemid"]),
  this.item1.itemname=this.itemForm.value["itemname"],
  this.item1.price=this.itemForm.value["price"],
  this.item1.stockno=Number(this.itemForm.value["stockno"]),
  this.item1.remarks=this.itemForm.value["remarks"],
  this.item1.description=this.itemForm.value["description"],
  this.item1.imagename=this.itemForm.value["imagename"],
  this.item1.sellerid=Number(localStorage.getItem('Sellerid'))
  this.service.UpdateItem(this.item1).subscribe(res=>{console.log(this.item1),alert("updated succesfully")},err=>{
    console.log(err)
  })
}

  Delete(itemid:number){
    this.service.DeleteItem(itemid).subscribe(res=>{
      alert("record deleted");
      console.log('Record deleted');
    },
    err=>{
      console.log(err);
    })
  }
  view(id:number)
{
 this.list1=new Items()
  this.service.GetItem(id).subscribe(
    res=>{
      this.list1=res;
      console.log(this.list1)
      localStorage.setItem("itemid",this.list1.itemid.toString())
      this.itemForm.patchValue({
        itemid:Number(this.list1.itemid),
          itemname:this.list1.itemname,
          price:this.list1.price,
          stockno:Number(this.list1.stockno),
          description:this.list1.description,
          remarks:this.list1.remarks,
          sellerid:Number(this.list1.sellerid),
          imagename:this.list1.imagename
        })
      })
    }
    Logout(){
      this.route.navigateByUrl('HOME');
    }
}

