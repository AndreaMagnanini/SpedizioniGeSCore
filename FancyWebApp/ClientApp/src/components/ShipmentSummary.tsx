// @ts-nocheck
import React from 'react'
import {
    makeStyles,
    Typography,
} from "@material-ui/core";
import RightArrow from './RightArrow';
import LongRightArrow from './LongRightArrow';
import CurvedDottedRightArrow from './CurvedDottedRightArrow';
import {useWindowSize} from "./useLayoutWindows";
import theme from "../styles/FerrariTheme";
import {useMediaQuery} from "@mui/material";
import VeryLongRightArrow from './VeryLongRightArrow';
import LongCurvedDottedRightArrow from './LongCurvedDottedRightArrow';
import MediumRightArrow from './MediumRightArrow';

const useStyles = makeStyles({
    container: {
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center"
    },
    summary: {
        display: "flex",
        flexDirection: "row",
        gap: "15px",
        alignItems: "center",
        justifyContent: "center"
    },
    summaryType:{
        marginTop: "-100px",
        gap: "15px",
        display: "flex",
        flexDirection: "row",
        alignItems: "center",
        justifyContent: "center",
    },
    summaryNames:{
        width: "100%",
        paddingBottom: "15px",
        gap: "15px",
        display: "flex",
        flexDirection: "row",
        alignItems: "center",
        justifyContent: "space-between",
    },
    summaryPorts: {
        maxWidth: "400px",
        display: "flex",
        flexDirection: "row",
        alignItems: "center",
        justifyContent: "space-between",
    },
    summaryPortsDetails: {
        maxWidth: "80px",
        gap: "160px",
        display: "flex",
        flexDirection: "row",
        alignItems: "center",
        justifyContent: "space-between",
    },
    summaryLocationRight: {
        marginRight: "-40px",
        maxWidth: "100px",
        gap: "160px",
        display: "flex",
        flexDirection: "row",
        alignItems: "center",
        justifyContent: "space-between",
    },
    summaryLocationLeft: {
        marginLeft: "-40px",
        maxWidth: "100px",
        gap: "160px",
        display: "flex",
        flexDirection: "row",
        alignItems: "center",
        justifyContent: "space-between",
    },
    summaryLocationDetails: {
        maxWidth: "100px",
        gap: "160px",
        display: "flex",
        flexDirection: "row",
        alignItems: "center",
        justifyContent: "space-between",
    },
    typeAir: {
        marginLeft: "-25px",
        marginTop: "-85px",
        filter: "invert(0.15)",
        paddingLeft: "20px",
        backgroundColor: "none",
        transform: "scale(0.9)",
        marginBottom: "-34px",
    },
    typeShip: {
        marginTop: "-70px",
        marginLeft: "-10px",
        filter: "invert(0.15)",
        paddingLeft: "10px",
        backgroundColor: "none",
        transform: "scale(0.8) ",
        marginBottom: "-10px",
    },
    typeGround: {
        marginTop: "30px",
        marginBottom: "-15px",
        transform: "scaleX(-1)"
    }
});

interface ShipmentSummaryProps{
    type: ShipmentType,
    origin: object,
    destination: object,
}

const ShipmentSummary: React.FC<ShipmentSummaryProps> = ({type, origin, destination}) => {
    const classes = useStyles();
    let originLocation = origin.location;
    let destinationLocation = destination.location;
    var originPort;
    var destinationPort;
    var originAirport;
    var destinationAirport;

    if(type === 'air' )
    {
        originAirport = origin.airport;
        destinationAirport = destination.airport;
    }
    else if (type === 'ship')
    {
        originPort = origin.port;
        destinationPort = destination.port;
    }

    const isMatch = useMediaQuery(theme.breakpoints.down('lg'))
    const [expanded, setExpanded] = React.useState(window.innerHeight > 900);
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

    let arrow =  expanded ? <MediumRightArrow/> : <RightArrow/>;
    let longArrow = expanded? <VeryLongRightArrow/> : <LongRightArrow/>;
    let curvedArrow = expanded? <LongCurvedDottedRightArrow></LongCurvedDottedRightArrow> : <CurvedDottedRightArrow></CurvedDottedRightArrow>;
    return (
        <div className={classes.container}>
            {type === 'ground'? <img alt="type"   className={classes.typeGround} src={require('../assets/camion.png')} height="30px" width="80px" /> : null}             
            <div className={classes.summary}>
                <img alt="alert"  src={require('../assets/1024px-Red_dot.svg.png')} height="25px" width="25px"></img>
                {type !== 'ground'?
                <div className={classes.summary}>
                    {arrow}
                    <img alt="alert"  src={require('../assets/1024px-Red_dot.svg.png')} height="25px" width="25px"></img>
                    {curvedArrow}
                    <img alt="alert"  src={require('../assets/1024px-Red_dot.svg.png')} height="25px" width="25px"></img>
                    {arrow}
                </div> :
                longArrow
                }
                <img alt="alert"  src={require('../assets/1024px-Red_dot.svg.png')} height="25px" width="25px"></img>
            </div>
            <div className={classes.summary}>
            {type=== 'air'? 
                    <div className={classes.summaryType}>
                        <img alt="type"  className={classes.typeAir} src={require('../assets/plane.png')} height="80px" width="80px" />
                    </div>
                : null}
                {type=== 'ship'? 
                    <div className={classes.summaryType}>
                        <img alt="type"   className={classes.typeShip} src={require('../assets/boat-with-containers.png')} height="60px" width="80px" />
                    </div>
                : null}
            </div>
            <div className={classes.summaryNames}>
                {type === 'ground'? 
                <div className={classes.summaryLocationLeft}>
                    <Typography variant="body1" color="textPrimary">{originLocation===undefined? '???' : originLocation}</Typography>
                </div> :
                <div className={classes.summaryLocationLeft} style={{marginTop: "-60px"}}>
                    <Typography variant="body1" color="textPrimary">{originLocation===undefined? '???' : originLocation}</Typography>
                </div>}
                {type=== 'air'? 
                    <div className={classes.summaryPorts} style={{gap: "180px"}}>
                    <div className={classes.summaryPortsDetails} style={{marginTop: "-60px"}}>
                       <Typography variant="body1" color="textPrimary">{originAirport===undefined? '???' : originAirport}</Typography>
                   </div>
                   <div className={classes.summaryPortsDetails} style={{marginTop: "-60px"}}>
                       <Typography variant="body1" color="textPrimary">{destinationAirport===undefined? '???' : destinationAirport}</Typography>
                   </div>
               </div>
                : null}
                {type=== 'ship'? 
                <div className={classes.summaryPorts} style={{gap: "160px"}}>
                     <div className={classes.summaryPortsDetails} style={{marginTop: "-60px"}}>
                        <Typography variant="body1" color="textPrimary">{originPort===undefined? '???' : originPort}</Typography>
                    </div>
                    <div className={classes.summaryPortsDetails} style={{marginTop: "-60px"}}>
                        <Typography variant="body1" color="textPrimary">{destinationPort===undefined? '???' : destinationPort}</Typography>
                    </div>
                </div>
                   
                : null}
                {type === 'ground'? 
                <div className={classes.summaryLocationRight}>
                    <Typography variant="body1" color="textPrimary">{destinationLocation===undefined? '???' : destinationLocation}</Typography>
                </div> :
                <div className={classes.summaryLocationRight} style={{marginTop: "-60px"}}>
                    <Typography variant="body1" color="textPrimary">{destinationLocation===undefined? '???' : destinationLocation}</Typography>
                </div>}
            </div>
        </div>
    )
}

export default ShipmentSummary;