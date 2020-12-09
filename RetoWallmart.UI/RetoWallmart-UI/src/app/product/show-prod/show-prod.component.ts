import { Component, OnInit } from '@angular/core';

import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-prod',
  templateUrl: './show-prod.component.html',
  styleUrls: ['./show-prod.component.css']
})
export class ShowProdComponent implements OnInit {

  constructor(private service:SharedService) { 
    
  } 

  ProductList:any=[];
  data:any=[];

  searchFilter:string = '';
  strSearchResults:string;

  p: number = 1;

  ngOnInit(): void {
    this.strSearchResults = "";
    this.refreshProductList("");

  }

  clickSearch(){
        this.strSearchResults = "";
        this.refreshProductList(this.searchFilter);
        this.p=1;
  }


  isNumeric(num){
    return !isNaN(num)
  }


  refreshProductList(searchStr){
    
    let formatter = new Intl.NumberFormat('es-CL', {
      style: 'currency',
      currency: 'CLP',
    });

    if(this.searchFilter == "" || this.isNumeric(this.searchFilter) || this.searchFilter.length > 3)
    {
      this.service.getProductList({"Description":searchStr.toLocaleLowerCase().trim()}).subscribe(data => {
        this.data = data;

        var content = this.data.contenido;

        content.forEach(function (value) {
          value.price = formatter.format(value.price);
          value.image = 'https://'+value.image;
        });

        this.ProductList = content;

        if(this.searchFilter == "")
          this.strSearchResults = this.ProductList.length +" record(s) found in total.";

        this.searchFilter = "";

        if(searchStr.length > 0)
              this.strSearchResults = this.ProductList.length +" record(s) found for: '"+ searchStr +"' ";
      })
    }      
    else{
      this.strSearchResults = "Please enter more than three (3) characters, or a product's Id, to trigger search.";
      this.ProductList = [];
    }};

  }
