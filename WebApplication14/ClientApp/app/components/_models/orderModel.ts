
export class OrderModel {
    constructor(UserId: string, Count: number) {
        this.UserId = UserId;
        this.Count = Count
    }
    public UserId: string;
    public Count: number;
}

