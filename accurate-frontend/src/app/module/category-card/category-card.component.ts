import { Component, Input } from '@angular/core';
import { category } from '../interfaces/category.interface';

@Component({
  selector: 'app-category-card',
  standalone: true,
  imports: [],
  templateUrl: './category-card.component.html',
  styleUrl: './category-card.component.css'
})
export class CategoryCardComponent {
  @Input()
  category!: category;
}
