import {Location} from './Location'
export interface Event{
    description: string;
    alias: string;
    location: Location;
    extraEu: boolean;
    eventNumber: number;
    start: Date;
    end: Date;
}