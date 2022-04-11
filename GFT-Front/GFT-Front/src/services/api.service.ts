import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { OrderRequest } from "src/models/order.request";
import { OrderResponse } from "src/models/order.response";

@Injectable({
  providedIn: "root"
})
export class ApiService {

  private get urlBase() {
    return "https://localhost:7137/";
  }

  constructor(private http: HttpClient) {

  }

  requestOrder(request: OrderRequest): Observable<OrderResponse> {
    return this.http.post<OrderResponse>(this.urlBase + 'order', request);
  }

}
