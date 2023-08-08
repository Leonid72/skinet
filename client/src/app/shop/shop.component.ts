import { Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import { ShopService } from './shop.service';
import { Product } from '../shared/models/product';
import { Brand } from '../shared/models/brand';
import { Type } from '../shared/models/type';
import { ShopParams } from '../shared/models/shopParams';


@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent  implements OnInit {

  constructor(private shopService : ShopService) {}
  @ViewChild('search') searchTerm : ElementRef;
  products : Product[] = [];
  brands: Brand[] = [];
  types: Type[] = [];
  shopParams = new ShopParams();
  sortOptions = [
    { name: 'Alphabetical', value:'name'},
    { name: 'Price: Low to high', value:'priceAsc'},
    { name: 'Price: High to low', value:'priceDesc'}
  ];
  totalCount = 0;

  ngOnInit(): void {
    this.getProduct();
    this.getBrands();
    this.getTypes();
  }
  getProduct(){
    this.shopService.getProducts(this.shopParams).subscribe({
      next: response => {
        this.products = response.data;
        //this.shopParams.pageSize = response.pageSize;
        //this.shopParams.pageNumber = response.pageIndex;
        this.totalCount = response.count;
      },
      error: error => console.log(error)
    });
  }
  getBrands(){
    this.shopService.getBrands().subscribe({
      next: response => this.brands = [{id : 0,name: 'All'},...response],
      error: error => console.log(error)
    });
  }
  getTypes(){
    this.shopService.getTypes().subscribe({
      next: response => this.types = [{id : 0,name: 'All'},...response],
      error: error => console.log(error)
    });
  }
  onBrandIdSelected(brandId: number){
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber= 1;
    this.getProduct();
  }
  onTypedIdSelected(typeId: number){
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber= 1;
    this.getProduct();
  }
  onSortSelected(event: any){
    this.shopParams.sort = event.target.value;
    this.getProduct();
  }
  onPageChanged(event: any){
    console.log(event.itemsPerPage);
    if(this.shopParams.pageNumber !== event){
    this.shopParams.pageNumber = event;
    this.getProduct();}
  }
  onSearch(){
    this.shopParams.search = this.searchTerm?.nativeElement.value
    this.shopParams.pageNumber= 1;
    this.getProduct();
  }
  onReste(){
    if(this.searchTerm) this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProduct();
  }
}
