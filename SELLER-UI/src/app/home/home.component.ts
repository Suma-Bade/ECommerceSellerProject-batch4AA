import { Component, OnInit } from '@angular/core';
//import { Token } from '@angular/compiler/src/ml_parser/lexer';
import { FormGroup, FormBuilder ,Validators} from '@angular/forms';
import { Seller } from '../Models/seller';
import { Router } from '@angular/router';
import { User } from '../Models/user';
import { AccountService } from '../services/account.service';
import {Token} from 'src/app/Models/token';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  submitted=false;
  userForm:FormGroup;
  seller:Seller;
  token:Token;
  constructor(private frombuilder:FormBuilder,private service:AccountService,private route:Router) { }

  ngOnInit() {
    this.userForm=this.frombuilder.group({
      username:['',[Validators.required,Validators.pattern("^[A-Za-z]{0,}$")]],
      password:['',[Validators.required,Validators.pattern("^[A-Za-z]{7,}[!@#$%^&*]")]]
    });
  }
  onSubmitLogin(){
    this.submitted=true;
      
    if(this.userForm.invalid){
     return;
    }
      else {
        this.token=new Token();
        this.seller=new Seller();
        let username=this.userForm.value['username']
        let password=this.userForm.value['password']
      this.service.SellerLogin(username,password).subscribe(res=>{this.token=res,console.log(this.token)
        if(this.token.message=="Success")
            {
              alert("welcome")
          console.log(this.token)
          localStorage.setItem("token",this.token.token);
          localStorage.setItem("Sellerid",this.token.sellerid.toString());
          this.route.navigateByUrl('/SELLER')
            }
            else{
              alert("invalid username or password")
              this.onReset();
            }
      });
    }
   }
    
    get f(){return this.userForm.controls;}
    onReset()
    {
      this.submitted=false;
      this.userForm.reset();
    }
}