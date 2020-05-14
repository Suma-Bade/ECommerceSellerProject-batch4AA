import { Component, OnInit } from '@angular/core';
import { Items } from 'src/app/Models/items';
import { FormGroup, FormBuilder ,Validators} from '@angular/forms';
import { ItemService } from 'src/app/services/item.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-items',
  templateUrl: './add-items.component.html',
  styleUrls: ['./add-items.component.css']
})
export class AddItemsComponent implements OnInit {
  list:Items[]=[];
  itemForm:FormGroup;
  submitted=false;
  item:Items;
  name:string;
  img:string;
  constructor(private frombuilder:FormBuilder,private service:ItemService,private route:Router) { 
   
  }

  ngOnInit() {
    this.itemForm=this.frombuilder.group({
      
      price:['',Validators.required],
      itemname:['',Validators.required],
      description:['',Validators.required],
      stockno:['',Validators.required],
      remarks:['',Validators.required],
      imagename:[''],
     // sid:['',Validators.required]
    });
  }
  AddItem(){
    this.submitted=true;
    if(this.itemForm.invalid){
     return;
    }
      else{
        this.item=new Items();
      this.item.itemid=Math.floor(Math.random()*1000);
      this.item.price=this.itemForm.value["price"];
      this.item.itemname=this.itemForm.value["itemname"];
      this.item.description=this.itemForm.value["description"];
      this.item.stockno=Number(this.itemForm.value["stockno"]);
      this.item.remarks=this.itemForm.value["remarks"];
      this.item.sellerid=Number(localStorage.getItem('Sellerid'))
      this.item.imagename=this.img;
      this.list.push(this.item);
      console.log(this.item);
      this.service.AddItem(this.item).subscribe(res=>{
        alert("Added succesfully");
      },err=>{
        console.log(err)
      })
      }
    }
    get f()
    {
      return this.itemForm.controls;
    }
   
    fileEvent(event){
      this.img = event.target.files[0].name;
  }
  
    
    onReset()
    {
      this.submitted=false;
      this.itemForm.reset();
    }
    
    Logout(){
      this.route.navigateByUrl('HOME');
    }

  }


