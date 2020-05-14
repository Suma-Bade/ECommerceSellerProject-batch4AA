import { Component, OnInit } from '@angular/core';
import { Seller } from 'src/app/Models/seller';
import {FormBuilder,FormGroup,Validators} from '@angular/forms';
import { AccountService } from 'src/app/services/account.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-seller-register',
  templateUrl: './seller-register.component.html',
  styleUrls: ['./seller-register.component.css']
})
export class SellerRegisterComponent implements OnInit {
  list:Seller[]=[];
  sellerForm:FormGroup;
  submitted=false;
  seller:Seller;
    constructor(private frombuilder:FormBuilder,private service:AccountService,private route:Router) { }
  
    ngOnInit() {
      this.sellerForm=this.frombuilder.group({
        sellerid:['',[Validators.required,Validators.pattern("^[0-9]{0,}$")]],
        username:['',[Validators.required,Validators.pattern("^[A-Za-z]{0,}$")]],
        password:['',[Validators.required,Validators.pattern("^[A-Za-z]{7,}[!@#$%^&*]")]],
        companyname:['',Validators.required],
        gst:['',Validators.required],
        aboutcmpy:['',Validators.required],
        address:['',Validators.required],
        website:['',Validators.required],
        mobileno:['',[Validators.required,Validators.pattern("^[6-9][0-9]{9}$")]],
        email:['',Validators.required]
      });
    }
    onSubmit(){
      this.submitted=true;
      if(this.sellerForm.invalid){
       return;
      }
        else{
          this.seller=new Seller();
        this.seller.sellerid=Number(this.sellerForm.value["sellerid"]);
        this.seller.username=this.sellerForm.value["username"];
        this.seller.password=this.sellerForm.value["password"];
        this.seller.companyname=this.sellerForm.value["companyname"];
        this.seller.gst=Number(this.sellerForm.value["gst"]);
        this.seller.aboutcmpy=this.sellerForm.value["aboutcmpy"];
        this.seller.address=this.sellerForm.value["address"];
        this.seller.website=this.sellerForm.value["website"];
        this.seller.mobileno=this.sellerForm.value["mobileno"];
        this.seller.email=this.sellerForm.value["email"];
        this.list.push(this.seller);
        console.log(this.seller);
        alert("added successfully");
        this.service.SellerRegister(this.seller).subscribe(res=>{
          this.route.navigateByUrl('HOME');
        },err=>{
          console.log(err)
        })
        }
      }
      get f(){return this.sellerForm.controls;}
      onReset()
      {
        this.submitted=false;
        this.sellerForm.reset();
      }
    }