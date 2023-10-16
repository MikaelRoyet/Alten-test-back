import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Product } from './product.class';


@Injectable({
  providedIn: 'root'
})
export class ProductsService {

    private static productslist: Product[] = null;
    private products$: BehaviorSubject<Product[]> = new BehaviorSubject<Product[]>([]);
    private urlBack: string = "https://localhost:7230/products/"

    constructor(private http: HttpClient) { }

    getProducts(): Observable<Product[]> {
        if( ! ProductsService.productslist )
        {
            this.http.get<any>(this.urlBack).subscribe(data => {
                ProductsService.productslist = data;
                this.products$.next(ProductsService.productslist);
            });
        }
        else
        {
            this.products$.next(ProductsService.productslist);
        }

        return this.products$;
    }

    create(prod: Product): Observable<Product[]> {
        const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };

        console.log(prod)
        this.http.post(this.urlBack, prod, httpOptions).subscribe({
            next: (response) => {
                ProductsService.productslist.push(prod);
                this.products$.next(ProductsService.productslist);
            }
        })

        return this.products$;
    }

    update(prod: Product): Observable<Product[]>{
        const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        ProductsService.productslist.forEach(element => {
            if(element.id == prod.id)
            {
                element.name = prod.name;
                element.category = prod.category;
                element.code = prod.code;
                element.description = prod.description;
                element.image = prod.image;
                element.inventoryStatus = prod.inventoryStatus;
                element.price = prod.price;
                element.quantity = prod.quantity;
                element.rating = prod.rating;
                console.log(element)
                this.http.put(this.urlBack + element.id, element, httpOptions).subscribe({
                    next: (response) => {
                        this.products$.next(ProductsService.productslist);
                    }
                })
            }

         
        });

        return this.products$;
    }


    delete(id: number): Observable<Product[]>{

        ProductsService.productslist = ProductsService.productslist.filter(value => { return value.id !== id } );


        this.http.delete(this.urlBack + id).subscribe({
            next: (response) => {
                this.products$.next(ProductsService.productslist);
            }
        })

        return this.products$;
    }
}