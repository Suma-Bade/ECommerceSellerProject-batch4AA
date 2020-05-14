import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-seller-landing-page',
  templateUrl: './seller-landing-page.component.html',
  styleUrls: ['./seller-landing-page.component.css']
})
export class SellerLandingPageComponent implements OnInit {

  sellerid:number;

  constructor(private route:Router) {
  
    }

  ngOnInit() {
  }
  Logout(){
    this.route.navigateByUrl('HOME');
  }

}

