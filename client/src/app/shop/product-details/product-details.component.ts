import { ShopService } from './../shop.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/shared/models/product';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  product? : Product;

  constructor(private shopService : ShopService,private activatedRoute : ActivatedRoute,
                    private brService: BreadcrumbService){}

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct(){
    const id = this.activatedRoute.snapshot.paramMap.get('id')
    if(id)  this.shopService.getProduct(+id).subscribe({
      next: product => {
        this.product = product;
        this.brService.set('@productDetails', product.name)
      },
        error: error => console.log(error)
    });

  }
}
