import { Component } from '@angular/core';
import { NavbarComponent } from '../../../../core/component/navbar/navbar.component';
import { FooterComponent } from '../../../../core/component/footer/footer.component'; 
// Import NavbarComponent

@Component({
  standalone: true,
  selector: 'app-product-detail',
  imports: [ NavbarComponent, FooterComponent],
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent {}
