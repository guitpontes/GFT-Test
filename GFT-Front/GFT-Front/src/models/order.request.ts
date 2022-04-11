export class OrderRequest {
    time?: string;
    orderList?: number[];

    constructor(params: Partial<OrderRequest>) {
        this.time = params.time;
        this.orderList = params.orderList;
      }
}