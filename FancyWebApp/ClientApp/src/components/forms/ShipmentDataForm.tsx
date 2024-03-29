import React, {useState} from 'react';
import { Typography, makeStyles, useMediaQuery } from '@material-ui/core';
import { ShipmentType } from '../interfaces/ShipmentType';
import { useFetchEvents } from '../../pages/useFetchEvents';
import { useFetchPorts } from '../../pages/useFetchPorts';
import { useFetchAirports } from '../../pages/useFetchAirports';
import { useFetchLocations } from '../../pages/useFetchLocations';
import { Event } from '../../abstractions/Event';
import { Port } from '../../abstractions/Port';
import { Airport } from '../../abstractions/Airport';
import { Location } from '../../abstractions/Location';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import {LocalizationProvider} from "@mui/x-date-pickers";
import ShipmentSummary from '../ShipmentSummary';
import EventSelector from '../selectors/EventSelector';
import PortSelector from '../selectors/PortSelector';
import AirportSelector from '../selectors/AirportSelector';
import LocationSelector from '../selectors/LocationSelector';
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';
import { Flag, isEuropeanLocation } from '../Flag';
import {EU} from "country-flag-icons/react/3x2";
import CircularProgress from '../CircularProgress';
import TriggeredLocationSelector from '../selectors/TriggeredLocationSelector';
import { useWindowSize } from '../useLayoutWindows';
import theme from '../../styles/FerrariTheme';
import { Divider } from '@mui/material';

const useStyles = makeStyles({
    mainDiv:{
        boxShadow: "5px 5px 25px rgba(0, 0, 0, 0.35)",
        display:"flex",
        width: "100%",
        flexDirection: "column",
        borderRadius: "10px",
        backgroundColor: "#eeeeee"
    },
    typeSelect: {
        marginTop: "5px",
        marginLeft: "10px"
    },
    mainContainer:{
        display: "flex",
        flexDirection: "row",
        gap: "15px",
        width: "100%"
    },
    header: {
        display: "flex",
        flexDirection: "row",
        height: "80px",
    },
    typeWrapper: {
        display: "flex",
        flexDirection: "row",
        gap: "0px",
        marginTop: "15px",
        marginBottom: "10px",
        backgroundColor: "#eeeeee",
    },
    typeAir: {
        marginTop: "-33px",
        filter: "invert(0.15)",
        paddingLeft: "20px",
        backgroundColor: "none",
        transform: "scale(0.9)",
        marginBottom: "-34px",
    },
    typeShip: {
        marginTop: "-17px",
        filter: "invert(0.15)",
        paddingLeft: "10px",
        backgroundColor: "none",
        transform: "scale(0.8) ",
        marginBottom: "-10px",
    },
    typeGround: {
        marginTop: "6px",
        marginBottom: "4px",
        filter: "invert(0.15)",
        paddingRight: "20px",
        backgroundColor: "none",
        transform: "scaleX(-1) scale(0.9)",
    },
    event:{
        height: "100%",
        alignItems: "center",
        display: "flex",
        flexDirection: "row",
        gap: "15px",
        paddingLeft: "10px",
        maxWidth: "550px",
        textOverflow: "ellipsis",
    },
    eventSelectDiv:{
        flexGrow: 1,
        width: "300px",
        textAlign: "center",
        alignItems:"center",
    },
    loader: {transform: "scale(0.1)"},
    location: {color: "#D41217"},
    portsWrapper: {
        gap: "15px",
        paddingLeft: "20px",
        display: "flex",
        flexDirection: "column",
        marginBottom: "10px"
    },
    airportsWrapper: {
        gap: "15px",
        paddingLeft: "20px",
        display: "flex",
        flexDirection: "column",
        marginBottom: "10px"
    },
    origin: {
        alignItems: "center",
        gap: "15px",
        display: "flex",
        flexDirection: "row"
    },
    destination: {
        alignItems: "center",
        gap: "15px",
        display: "flex",
        flexDirection: "row"
    },
    separator:{
        marginBottom: "20px",
        marginTop: "10px",
    },
    widerSeparator:{
        marginBottom: "20px",
        marginTop: "10px",
    },
    dates:{
        gap: "15px",
        display: "flex",
        flexDirection: "row",
        marginBottom: "10px",
        justifyContent: "center",
        alignItems: "center",
    },
    locationFlags:{
        display: "flex",
        flexDirection: "row",
        gap: "10px",
        alignItems: "end",
        justifyContent: "right"
    },
    euFlag: {
        height: "30px"
    },
    dateWarning: {
        display: "flex",
        flexDirection: "row",
        gap: "20px",
        alignItems: "center",
        justifyContent: "center",
    },
    summary: {
        display: "flex",
        flexDirection: "row",
        gap: "15px",
        alignItems: "center",
        justifyContent: "center"
    },
    summaryNames:{
        display: "flex",
        flexDirection: "row",
        gap: "15px",
        alignItems: "center",
        justifyContent: "center",
    },
    stripes:{
        overflow: "hidden",
        marginTop: "2px",
        filter: "invert(0.15)",
        marginLeft: "-133px",
        marginRight: "-74px",
        backgroundColor: "none",
        transform: "scale(0.9)",
    },
    stripesIfShip:{
        overflow: "hidden",
        marginTop: "-7px",
        filter: "invert(0.15)",
        marginLeft: "-129.1px",
        marginRight: "-54px",
        backgroundColor: "none",
        transform: "scale(0.9)",
    }
});

interface ShipmentDataFormProps{
    year: number;
    shipmentType: ShipmentType;
}

const ShipmentDataForm: React.FC<ShipmentDataFormProps> = ({year, shipmentType}) =>{
    
    const classes = useStyles();

    const [events, eventsAreLoading] = useFetchEvents(year);
    const [ports, portsAreLoading] = useFetchPorts();
    const [airports, airportsAreLoading] = useFetchAirports();
    const [locations, locationsAreLoading] = useFetchLocations();

    const [event, setEvent] = useState<Event>(null);
    const [originPort, setOriginPort] = useState<Port>(null);
    const [destinationPort, setDestinationPort] = useState<Port>(null);
    const [originAirport, setOriginAirport] = useState<Airport>(null);
    const [destinationAirport, setDestinationAirport] = useState<Airport>(null);
    const [originLocation, setOriginLocation] = useState<Location>(null);
    const [destinationLocation, setDestinationLocation] = useState<Location>(null);
    const [departureDate, setDepartureDate] = useState<Date>();
    const [returnDate, setReturnDate] = useState<Date>();
    const [showDateWarning, setShowDateWarning] = useState(false);
    const [expanded, setExpanded] = React.useState(window.innerHeight > 900);
    
    const isMatch = useMediaQuery(theme.breakpoints.down('lg'))
    const config = isMatch ? {height: "100%", display:"flex", marginTop: "25px", marginBottom:"30px", }
    : {height: "100%", display:"flex", marginTop: "25px", marginBottom:"30px",};


    const headerConfig = !isMatch? 
        {gap: "100px", marginRight: "20px", marginTop: "30px", marginBottom: "-10px", marginLeft: "110px"} : 
        {gap: "15px", marginRight: "20px", marginTop: "15px", marginBottom: "-10px"};
    const bigAutocompleteConfig = !isMatch ? 
        {width: "400px", paddingTop: "5px"} : 
        {width: "300px", paddingTop: "5px"};
    const smallAutocompleteConfig = !isMatch? 
        {width: "400px", marginLeft: "30px", marginRight: "30px"} :   
        {width: "300px"};
    const dividersConfig = !isMatch? 
        {marginTop: "30px", marginBottom: "40px"} :
        {};
   
    window.addEventListener('resize', () => expandElements());
    
    let [width, height] = useWindowSize();

    function handleExpansion(expand){
        if(expand !== undefined){
            setExpanded(expand);
        } 
        else{
            setExpanded(!expanded);
        }
    }

    function expandElements(){
        if(window.innerHeight > 900){
            handleExpansion(true);
        }

        if(window.innerHeight < 900){
            handleExpansion(false);
        }
    }

    const onEventSelected = (eventName: string): void => {
        let selected = events.filter(e => e.description === eventName)[0];
        if(!(selected === undefined)){
            setEvent(selected);
            console.log(selected.description);
            if(selected.location!== undefined && selected.location !== null){
                let correspondingLocation = locations.filter(l => 
                    (l.name.toLowerCase().includes(selected.location.name?.toLowerCase()) || 
                     l.name.toLowerCase().includes(selected.location.city?.toLowerCase()) ||
                     l.name.toLowerCase().includes(selected.location.address?.toLowerCase()) ||
                     l.name.toLowerCase().includes(selected.location.nation?.toLowerCase()) ||
                     selected.description.toLowerCase().includes(l.name?.toLowerCase()) ||
                     selected.description.toLowerCase().includes(l.city?.toLowerCase()) ||
                     selected.description.toLowerCase().includes(l.nation?.toLowerCase())
                     ))[0];
                if(!(correspondingLocation===undefined)){
                    if(destinationLocation===null){
                        setDestinationLocationFromSelect(correspondingLocation.name);
                    }
                }
            }
        }
        else{
            setEvent(null);
            setDestinationLocationFromSelect(null);
            console.log("reset event");
        }
    };

    const setOriginPortFromSelect = (portName: string): void  => {
        let selected = ports.filter(e => e.name === portName)[0];
        if(!(selected === undefined)){
            setOriginPort(selected);
            console.log(selected.city);
        }
        else{
            setOriginPort(null);
            console.log("reset origin port");
        }
    }

    const setDestinationPortFromSelect = (portName: string)  => {
        let selected = ports.filter(e => e.name === portName)[0];
        if(!(selected === undefined)){
            setDestinationPort(selected);
            console.log(selected.city);
        }
        else{
            setDestinationPort(null);
            console.log("reset destination port");
        }
    }

    const setOriginAirportFromSelect = (airportName : string)  => {
        let selected = airports.filter(e => e.name === airportName)[0];
        if(!(selected === undefined)){
            setOriginAirport(selected);
            console.log(selected.city);
        }
        else{
            setOriginAirport(null);
            console.log("reset origin airport");
        }
    }

    const setDestinationAirportFromSelect = (airportName: string)  => {
        let selected = airports.filter(e => e.name === airportName)[0];
        if(!(selected === undefined)){
            setDestinationAirport(selected);
            console.log(selected.city);
        }
        else{
            setDestinationAirport(null);
            console.log("reset destination airport");
        }
    }

    const setOriginLocationFromSelect = (locationName: string)  => {
        let selected = locations.filter(e => e.name === locationName)[0];
        if(!(selected === undefined)){
            setOriginLocation(selected);
            console.log(selected.city);
        }
        else{
            setOriginLocation(null);
            console.log("reset origin location");
        }
    }

    const setDestinationLocationFromSelect = (locationName: string)  => {
        let selected = locations.filter(e => e.name === locationName)[0];
        if(!(selected === undefined)){
            setDestinationLocation(selected);
            console.log(selected.city);
        }
        else{
            setDestinationLocation(null);
            console.log("reset destination location");
        }
    }

    const setDepartureDateFromDatePicker = (date: Date, nextDate: Date) => {
        if((nextDate !== undefined && nextDate !== null)){
            if(nextDate.getTime() < date.getTime()){
                setShowDateWarning(true);
            }
            else {
                setShowDateWarning(false);
            }
        }
        console.log(date);
        var newValue = new Date(date);
        setDepartureDate(newValue);
    }

    const setReturnDateFromDatePicker = (date: Date, previousDate: Date) => {
        if((previousDate !== undefined && previousDate !== null)){
            if(previousDate.getTime() > date.getTime()){
                setShowDateWarning(true);
            }
            else {
                setShowDateWarning(false);
            }
        }
        console.log(date);
        var newValue = new Date(date);
        setReturnDate(newValue);
    }
    
    return (
        <div style={{ width: "100%", display: "flex" , paddingTop: "50px", flexDirection: "column", margin: "10px"}}>
            <div className={classes.mainDiv} style={config}>
                <div className={classes.header} style={headerConfig}>
                    <div className={classes.typeWrapper}>
                        {!isMatch? <img alt="type" className={shipmentType !== 'ship'? classes.stripes : classes.stripesIfShip} src={require('../../assets/Counting_rod_horizontal_red_3.svg.png')} height={shipmentType !== 'ship'? "51px": "62px"} width={shipmentType !== 'ship'? "200px": "170px"}/> : null}
                        {shipmentType === 'air'? <img alt="type"  className={classes.typeAir} src={require('../../assets/plane.png')} height="120px" width="120px" /> : null}
                        {shipmentType === 'ship'? <img alt="type"   className={classes.typeShip} src={require('../../assets/boat-with-containers.png')} height="80px" width="120px" /> : null}
                        {shipmentType === 'ground'? <img alt="type"   className={classes.typeGround} src={require('../../assets/camion.png')} height="43px" width="120px" /> : null}
                    </div>
                    <div className={classes.event}>
                        <Typography variant="h6">Event</Typography>
                        <EventSelector options={events} callback={onEventSelected} style={bigAutocompleteConfig} />
                        {eventsAreLoading? <CircularProgress className={classes.loader}/> : null}
                        {event === null? null : <Typography variant="body1" className={classes.location}>{event.location !== null ? event.location.name : ''}</Typography>}
                    </div>
                </div>
                {shipmentType === 'ship' ?<div className={classes.separator} style={dividersConfig}>
                    <Divider variant="middle" >
                        Ports
                    </Divider>
                </div> : null}
                {shipmentType === 'air' ?<div className={classes.separator}  style={dividersConfig}>
                    <Divider variant="middle">
                        Airports
                    </Divider>
                </div> : null}
                {shipmentType === 'ship' ?<div className={classes.portsWrapper} style={!isMatch? {gap:"30px"} : undefined}>
                    <div className={classes.origin}>
                        <Typography style={{paddingRight: "62px"}} variant="subtitle1">Origin</Typography>
                        <PortSelector options={ports} callback={setOriginPortFromSelect} style={smallAutocompleteConfig}/>
                        {originPort === null? null : <Typography className={classes.location}>{originPort.loCode !== null ? originPort.loCode : ''}</Typography>}
                    </div>
                    <div className={classes.destination}>
                        <Typography variant="subtitle1">Destination</Typography>
                        <PortSelector options={ports} callback={setDestinationPortFromSelect} style={smallAutocompleteConfig}/>
                        {destinationPort === null? null : <Typography className={classes.location}>{destinationPort.loCode !== null ? destinationPort.loCode : ''}</Typography>}
                    </div>
                </div> : null}
                {shipmentType === 'air' ?<div className={classes.airportsWrapper} style={!isMatch? {gap:"30px"} : undefined}>
                    <div className={classes.origin}>
                        <Typography style={{paddingRight: "62px"}} variant="subtitle1">Origin</Typography>
                        <AirportSelector options={airports} callback={setOriginAirportFromSelect} style={smallAutocompleteConfig}/>
                        {originAirport === null? null : <Typography className={classes.location}>{originAirport.iataCode !== null ? originAirport.iataCode : ''}</Typography>}
                    </div>
                    <div className={classes.destination}>
                        <Typography variant="subtitle1">Destination</Typography>
                        <AirportSelector options={airports} callback={setDestinationAirportFromSelect} style={smallAutocompleteConfig}/>
                        {destinationAirport === null? null : <Typography className={classes.location}>{destinationAirport.iataCode !== null ? destinationAirport.iataCode : ''}</Typography>}
                </div>
                </div>: null}
                <div className={classes.separator} style={dividersConfig}>
                    <Divider variant="middle">
                        Locations
                    </Divider>
                </div>
                <div className={classes.airportsWrapper} style={!isMatch? {gap:"30px"} : undefined}>
                    <div className={classes.origin}>
                        <Typography style={{paddingRight: "62px"}} variant="subtitle1">Origin</Typography>
                        <LocationSelector options={locations} callback={setOriginLocationFromSelect} style={smallAutocompleteConfig}/>
                        {(originLocation === undefined || originLocation === null)? null : <div className={classes.locationFlags}>
                            {isEuropeanLocation(originLocation.nation)? <EU title="European Union" className={classes.euFlag}/> : null}
                            <Flag country={originLocation.nation}/>
                        </div>}
                    </div>
                    <div className={classes.destination}>
                        <Typography variant="subtitle1">Destination</Typography>
                        <TriggeredLocationSelector triggeredValue={destinationLocation} options={locations} callback={setDestinationLocationFromSelect} style={smallAutocompleteConfig}/>
                        {(destinationLocation === null)? null : <div className={classes.locationFlags}>
                            {isEuropeanLocation(destinationLocation.nation)? <EU title="European Union" className={classes.euFlag}/> : null}
                            <Flag country={destinationLocation.nation}/>
                        </div>}
                </div>
                </div>
                <div className={classes.separator} style={!isMatch? dividersConfig : {marginTop: "5px", marginBottom: "5px"}}>
                    <Divider variant="middle">
                        Dates
                    </Divider>
                </div>
                <div className={classes.dates} style={isMatch? {marginTop:"10px"} : undefined}>
                    <LocalizationProvider dateAdapter={AdapterDateFns}>
                        {!isMatch? <Typography style={{paddingRight: "10px", marginLeft: "-30px"}} variant="subtitle1">Departure date</Typography>: null}
                        <DatePicker label="Departure" 
                            format="dd/MM/yyyy"
                            onChange={(value: Date) => setDepartureDateFromDatePicker(value, returnDate)}/>
                        {!isMatch? <Typography style={{paddingRight: "10px", paddingLeft: "40px"}} variant="subtitle1">Leaving date</Typography>: null}
                        <DatePicker label="Return/Leaving" 
                            format="dd/MM/yyyy"
                            onChange={(value: Date) => setReturnDateFromDatePicker(value, departureDate)}/>
                    </LocalizationProvider>
                </div>
                {showDateWarning? <div className={classes.dateWarning}>
                    <img alt="alert"  src={require('../../assets/warning-5-48.png')} height="25px" width="25px" />
                    <Typography style={{color: "#D41217"}} variant="subtitle1">Please select a correct date range</Typography>
                </div> : null}
                <div className={classes.separator} style={!isMatch? dividersConfig :{marginTop: "5px", marginBottom: "5px"}}>
                    <Divider variant="middle">
                        <Typography style={{color: "#D41217"}} variant="body1">Summary</Typography>
                    </Divider>
                </div>
                <div className={classes.summary}>
                    {shipmentType === 'air'?
                    <ShipmentSummary 
                        type={shipmentType}
                        origin={{location: originLocation?.name, airport: originAirport?.iataCode }}
                        destination={{location: destinationLocation?.name, airport: destinationAirport?.iataCode}}/> : null}
                    {shipmentType === 'ship'?
                    <ShipmentSummary 
                        type={shipmentType}
                        origin={{location: originLocation?.name, port: originPort?.loCode }}
                        destination={{location: destinationLocation?.name, port: destinationPort?.loCode}}/> : null}
                    {shipmentType === 'ground'?
                    <ShipmentSummary 
                        type={shipmentType}
                        origin={{location: originLocation?.name }}
                        destination={{location: destinationLocation?.name}}/> : null}
                </div>
            </div>
        </div>
    );
}

export default ShipmentDataForm;