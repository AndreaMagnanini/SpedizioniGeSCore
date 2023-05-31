import {Event} from './Event';
import {Location} from "./Location";
export interface Shipment{
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