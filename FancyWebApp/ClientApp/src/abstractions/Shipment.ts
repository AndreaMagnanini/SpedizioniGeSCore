import {Event} from './Event';
import {Location} from "./Location";
export class Shipment{
    Id: number;
    Code: string;
    Description: string;
    Event: Event;
    Origin: Location;
    Destination: Location;
    OriginAirport: string;
    DestinationAirport: string;
    Departure: Date;
    Arrive: Date;
    Status: string;
}