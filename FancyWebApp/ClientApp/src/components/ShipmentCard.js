// @ts-nocheck
import React from 'react';
import {
    Accordion,
    AccordionDetails, AccordionSummary, Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle,
    makeStyles, Tooltip,
    Typography, useTheme
} from "@material-ui/core";
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';
import DeleteSharpIcon from '@material-ui/icons/DeleteSharp';
import EditSharpIcon from '@material-ui/icons/EditSharp';
import ReplayIcon from '@material-ui/icons/Replay';
import GetAppIcon from '@material-ui/icons/GetApp';
import ArrowDownwardIcon from '@material-ui/icons/ArrowDownward';
import {IconButton} from "@material-ui/core";
import {green, red} from "@material-ui/core/colors";
import {Flag} from "./Flag";
import {EU} from "country-flag-icons/react/3x2";
import {useNavigate} from "react-router-dom";
import {TransitionGroup} from 'react-transition-group';
import {useWindowSize} from "./useLayoutWindows";
import {useMediaQuery} from "@mui/material";

const useStyles = makeStyles({
    cardContainer:{
        overflow: "hidden",
        display: "flex",
        flexDirection: "column",
        border: "1px solid #000012",
        borderRadius: 10,
        transition: "transform 0.15s ease-in-out",
        '&:hover': {
            boxShadow: "5px 5px 25px rgba(0, 0, 0, 0.35)",
            transform: "scale3d(1.05, 1.05, 1)",
            marginRight: ""
        },
        animation: "$appear"
    },
    "@keyframes appear": {
        "0%": {
            transform: "translateY(-20%)"
        },
        "100%": {
            transform: "translateY(0%)"
        }
    },
    cardHeader: {
        paddingRight: "16px",
        justifyContent: "right",
        weight: "100%",
        padding: "8px",
        display: "flex",
        flex: "1",
        background: "linear-gradient(90deg, rgba(231,14,14,1) 0%, rgba(165,22,22,1) 66%)",
        height: "100px",
    },
    cardTitle:{
        color:"#000"
    },
    cardContent:{
        flexDirection: "column",
        display: "flex",
        flex: "5",
        backgroundColor: "#eeeeee",
    },
    summaryTitle:{
        backgroundColor: "#eeeeee",
    },
    typeWrapper: {
        backgroundColor: "#eeeeee",
        zIndex: 1
    },
    typeAir: {
        filter: "invert(0.15)",
        paddingLeft: "20px",
        backgroundColor: "none",
        transform: "translateY(-65%) scale(0.9)",
        marginBottom: "-120px",
        zIndex: "2",
    },
    typeShip: {
        filter: "invert(0.15)",
        paddingLeft: "10px",
        backgroundColor: "none",
        transform: "translateY(-80%) scale(0.8) ",
        marginBottom: "-80px",
        zIndex: "2",
    },
    typeGround: {
        filter: "invert(0.15)",
        paddingRight: "20px",
        backgroundColor: "none",
        transform: "translateY(-90%) scaleX(-1) scale(0.9)",
        marginBottom: "-50px",
        zIndex: "2",
    },
    status:{
        display: "flex",
        flexDirection: "row",
        flex: 1,
        backgroundColor: "#eeeeee",
        justifyContent: "space-between",
        padding: " 10px 16px"
    },
    actions: {
        display: "flex",
        flexDirection: "row",
        flex: 1,
        gap: "10px",
        backgroundColor: "#fff",
        justifyContent: "right",
        padding: " 10px 16px"
    },
    details: {
        display: "flex",
        flexDirection: "column",
    },
    detailsDateWrapper: {
        marginBottom: "10px",
        justifyContent: "space-between",
        display: "flex",
        flexDirection: "row",
        backgroundColor: "none"
    },
    eventDetails:{
        display: "flex",
        flexDirection: "row",
        justifyContent: "space-between",
        width: "100%"
    },
    eventDetailsText:{
        display: "flex",
        maxWidth: "300px"
    },
    eventDetailsFlags:{
        display: "flex",
        flexDirection: "row",
        gap: "10px",
        alignItems: "end",
        justifyContent: "right"
    },
    euFlag: {
        height: "30px"
    },
    airportsWrapper:{
        display: "flex",
        flexDirection: "column",
        width: "100%",
        justifyContent: "center"
    },
    portsWrapper: {
        display: "flex",
        flexDirection: "column",
        width: "100%",
        justifyContent: "center"
    },
    originWrapper: {
        textAlign: "center"
    },
    arrowWrapper: {
        marginTop:"5px",
        marginBottom:"5px",
        display: "flex",
        width: "100%",
        justifyContent: "center"
    },
    destinationWrapper: {
        textAlign: "center"
    },
    dialogTitle: {
        background: "linear-gradient(90deg, rgba(231,14,14,1) 0%, rgba(165,22,22,1) 66%)",
    },
    dialogContentWrapper: {
        display: "flex",
        flexDirection: "row",
        gap: "30px"
    },
    "example-enter": {
        opacity: "0.01",
        "&.example-enter-active": {
            opacity: "1",
            transition: "opacity 3s ease-in"
        }
    },
    "example-appear": {
        opacity: "0.01",
        "&.example-appear-active": {
            opacity: "1",
            transition: "opacity 3s ease-in"
        }
    },

    "&.example-appear-active": {
        opacity: "1",
        transition: "opacity 3s ease-in"
    }
});

function ShipmentCard({shipment}) {

    const theme = useTheme();
    const isMatch = useMediaQuery(theme.breakpoints.down('lg'))

    // Subset of props, to illustrate the idea.
    const config = isMatch ? {width: "400px"} : {width: "500px"};

    const navigate = useNavigate()
    const classes = useStyles();
    const displayAir = (shipment.type === 0);
    const displayShip = (shipment.type === 1);
    const displayGround = (shipment.type === 2);
    const [deleteDialogOpen, setDeleteDialogOpen] = React.useState(false);
    const [revertDialogOpen, setRevertDialogOpen] = React.useState(false);
    const [expanded, setExpanded] = React.useState(window.innerHeight > 900);
    const [contentExpanded, setContentExpanded] = React.useState(window.innerHeight > 900);

    window.addEventListener('resize', () => expandElements());
    let [width, height] = useWindowSize();
    let status = '';
    if(shipment.status===0) status = 'scheduled';
    else if(shipment.status===1) status = 'departed';
    else if(shipment.status===2) status = 'arrived';

    let startingDate = shipment.event.start.split('T')[0].replaceAll('-', '/');
    let endingDate = shipment.event.end.split('T')[0].replaceAll('-', '/');

    function handleContentExpansion(expand){
        if(expand !== undefined){
            setContentExpanded(expand);
        } 
        else{
            setContentExpanded(!contentExpanded);
        }
    }

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
            handleContentExpansion(true);
        }

        if(window.innerHeight < 900){
            handleExpansion(false);
            handleContentExpansion(false);
        }
    }
    
    function downloadShipment(){

    }

    function revertShipment(){
        setRevertDialogOpen(false);
    }

    function deleteShipment(){
        setDeleteDialogOpen(false);
    }

    function editShipment () {
        let path = 'shipment/' + shipment.id;
        navigate(path);
    }

    return (
        <TransitionGroup
            transitionName="example"
            transitionAppear={true}
            transitionAppearTimeout={500}
            transitionEnter={true}
            transitionLeave={false}>
            <div className={classes.cardContainer} style={config}>
                <div className={classes.cardHeader}>
                    <Typography  style={{fontWeight: 600}} align='right' className={classes.cardTitle} variant="h4">
                        {shipment.code}
                    </Typography>
                </div>
                <div className={classes.typeWrapper}>
                    {displayAir? <img alt="type"  className={classes.typeAir} src={require('../assets/plane.png')} height="120px" width="120px" /> : null}
                    {displayShip? <img alt="type"   className={classes.typeShip} src={require('../assets/boat-with-containers.png')} height="80px" width="120px" /> : null}
                    {displayGround? <img alt="type"   className={classes.typeGround} src={require('../assets/camion.png')} height="45px" width="120px" /> : null}
                </div>
                <div className={classes.cardContent}>
                    <Accordion defaultExpanded style={{ boxShadow: "none" }} disableGutters>
                        <AccordionSummary
                            className={classes.summaryTitle}
                            expandIcon={<ExpandMoreIcon />}
                            aria-controls="panel1a-content"
                            id="panel1a-header"
                        >
                            <Typography >Event</Typography>
                        </AccordionSummary>
                        <AccordionDetails className={classes.details}>
                            <div className={classes.eventDetails} style={{paddingTop: "10px", paddingBottom: "10px"}}>
                                <div className={classes.eventDetailsText}>
                                    <Typography style={{fontWeight: "600"}}>
                                        {shipment.event.description} <br/>
                                    </Typography>
                                </div>
                                <div className={classes.eventDetailsFlags}>
                                    {!shipment.event.extraEU? <EU title="European Union" className={classes.euFlag}></EU> : null}
                                    <Flag country={shipment.event.location.nation}></Flag>
                                </div>
                            </div>
                            <div className={classes.detailsDateWrapper}>
                                <Typography style={{color: red[500]}}>Starting:</Typography>
                                <Typography style={{fontWeight: "600"}}>{startingDate}</Typography>
                            </div>
                            <div className={classes.detailsDateWrapper}>
                                <Typography style={{color: red[500]}}>Ending:</Typography>
                                <Typography style={{fontWeight: "600"}}>{endingDate}</Typography>
                            </div>
                        </AccordionDetails>
                    </Accordion>
                    <Accordion style={{ boxShadow: "none" }} disableGutters>
                        <AccordionSummary
                            className={classes.summaryTitle}
                            expandIcon={<ExpandMoreIcon />}
                            aria-controls="panel1a-content"
                            id="panel1a-header"
                        >
                            <Typography >Origin</Typography>
                        </AccordionSummary>
                        <AccordionDetails>
                            <div className={classes.eventDetails}>
                                <div className={classes.eventDetailsText}>
                                    <Typography>
                                        {shipment.origin.name} <br/>
                                        {shipment.origin.address} <br/>
                                        {shipment.origin.city}, {shipment.origin.nation}
                                    </Typography>
                                </div>
                                <div className={classes.eventDetailsFlags}>
                                    <Flag country={shipment.origin.nation}></Flag>
                                </div>
                            </div>
                        </AccordionDetails>
                    </Accordion>
                    <Accordion style={{ boxShadow: "none" }} disableGutters>
                        <AccordionSummary
                            className={classes.summaryTitle}
                            expandIcon={<ExpandMoreIcon />}
                            aria-controls="panel1a-content"
                            id="panel1a-header"
                        >
                            <Typography >Destination</Typography>
                        </AccordionSummary>
                        <AccordionDetails>
                            <div className={classes.eventDetails}>
                                <div className={classes.eventDetailsText}>
                                    <Typography>
                                        {shipment.destination.name} <br/>
                                        {shipment.destination.address} <br/>
                                        {shipment.destination.city}, {shipment.destination.nation}
                                    </Typography>
                                </div>
                                <div className={classes.eventDetailsFlags}>
                                    <Flag country={shipment.destination.nation}></Flag>
                                </div>
                            </div>
                        </AccordionDetails>
                    </Accordion>
                    { (displayAir || displayShip )? <Accordion style={{boxShadow: "none"}} defaultExpanded={height > 900} expanded={expanded} onChange={() => handleExpansion()}>
                        <AccordionSummary
                            className={classes.summaryTitle}
                            expandIcon={<ExpandMoreIcon/>}
                            aria-controls="panel1a-content"
                            id="panel1a-header"
                        >
                            <Typography>{displayAir? 'Airports' : 'Ports'}</Typography>
                        </AccordionSummary>
                        <AccordionDetails>
                            {displayShip? <div className={classes.portsWrapper}>
                                <div className={classes.originWrapper}>
                                    <Typography>
                                        {shipment.originPort.name} <br/>
                                        {shipment.originPort.city} <br/>
                                        {shipment.originPort.description}
                                    </Typography>
                                </div>
                                <div className={classes.arrowWrapper}>
                                    <ArrowDownwardIcon color="primary" fontSize="large"></ArrowDownwardIcon>
                                </div>
                                <div className={classes.destinationWrapper}>
                                    <Typography>
                                        {shipment.destinationPort.name} <br/>
                                        {shipment.destinationPort.city} <br/>
                                        {shipment.destinationPort.description}
                                    </Typography>
                                </div>
                            </div>: null}
                            {displayAir? <div className={classes.airportsWrapper}>
                                <div className={classes.originWrapper}>
                                    <Typography>
                                        {shipment.originAirport.iataCode} - {shipment.originAirport.name} <br/>
                                        {shipment.originAirport.city} <br/>
                                        {shipment.originAirport.description}
                                    </Typography>
                                </div>
                                <div className={classes.arrowWrapper}>
                                    <ArrowDownwardIcon color="primary" fontSize="large"></ArrowDownwardIcon>
                                </div>
                                <div className={classes.destinationWrapper}>
                                    <Typography>
                                        {shipment.destinationAirport.iataCode} - {shipment.destinationAirport.name} <br/>
                                        {shipment.destinationAirport.city} <br/>
                                        {shipment.destinationAirport.description}
                                    </Typography>
                                </div>
                            </div>: null}

                        </AccordionDetails>
                    </Accordion> : null}
                    <Accordion style={{ boxShadow: "none" }} defaultExpanded={height > 900} expanded={contentExpanded} onChange={() => handleContentExpansion()}>
                        <AccordionSummary
                            className={classes.summaryTitle}
                            expandIcon={<ExpandMoreIcon />}
                            aria-controls="panel1a-content"
                            id="panel1a-header"
                        >
                            <Typography >Content</Typography>
                        </AccordionSummary>
                        <AccordionDetails>
                            <Typography>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse malesuada lacus ex,
                                sit amet blandit leo lobortis eget.
                            </Typography>
                        </AccordionDetails>
                    </Accordion>
                    <div className={classes.status}>
                        <Typography variant="body1">Status:</Typography>
                        <Typography style={{paddingLeft: "10px", fontWeight: "900"}} variant="body1">{status}</Typography>
                    </div>
                    <div className={classes.actions}>
                        {shipment.status!==0 ?
                        <Tooltip title="revert">
                            <IconButton aria-label="revert status" onClick={() => setRevertDialogOpen(true)}>
                                <ReplayIcon fontSize="medium" style={{color: green[500]}}></ReplayIcon>
                            </IconButton>
                        </Tooltip>: null}
                        <Tooltip title="download documentation">
                            <IconButton aria-label="download documentation" onClick={() => downloadShipment()}>
                                <GetAppIcon fontSize="medium" color="primary"></GetAppIcon>
                            </IconButton>
                        </Tooltip>
                        <Tooltip title="edit">
                            <IconButton aria-label="edit" onClick={() => editShipment()}>
                                <EditSharpIcon fontSize="medium"></EditSharpIcon>
                            </IconButton>
                        </Tooltip>
                        <Tooltip title="delete">
                           <IconButton aria-label="delete" onClick={() => setDeleteDialogOpen(true)}>
                               <DeleteSharpIcon fontSize="medium"></DeleteSharpIcon>
                           </IconButton>
                        </Tooltip>
                    </div>
                </div>
                <Dialog
                    open={deleteDialogOpen}
                    aria-labelledby="alert-dialog-title"
                    aria-describedby="alert-dialog-description"
                >
                    <DialogTitle id="alert-dialog-title" className={classes.dialogTitle} sx={{color: "#fff", fontWeight: 800}}>
                        {"Delete Command"}
                    </DialogTitle>
                    <DialogContent>
                        <div className={classes.dialogContentWrapper}>
                            <img alt="alert"  src={require('../assets/warning-5-48.png')} height="50px" width="50px" />
                            <DialogContentText color='black' id="alert-dialog-description-delete">
                                Sure you want to delete shipment {shipment.code} from shipments list?
                            </DialogContentText>
                        </div>
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={() => setDeleteDialogOpen(false)}>Cancel</Button>
                        <Button color='primary' onClick={() => deleteShipment()} autoFocus>
                            Delete
                        </Button>
                    </DialogActions>
                </Dialog>
                <Dialog
                    open={revertDialogOpen}
                    aria-labelledby="alert-dialog-title"
                    aria-describedby="alert-dialog-description"
                >
                    <DialogTitle id="alert-dialog-title" className={classes.dialogTitle} sx={{color: "#fff", fontWeight: 800}}>
                        {"Revert Command"}
                    </DialogTitle>
                    <DialogContent>
                        <div className={classes.dialogContentWrapper}>
                            <img alt="alert"  src={require('../assets/warning-5-48.png')} height="50px" width="50px" />
                            <DialogContentText color='black' id="alert-dialog-description-delete">
                                Sure you want to revert shipment {shipment.code} from state {shipment.status === 1? 'DEPARTED' : 'ARRIVED'} to state {shipment.status === 1? 'SCHEDULED' : 'DEPARTED'}?
                            </DialogContentText>
                        </div>
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={() => setRevertDialogOpen(false)}>Cancel</Button>
                        <Button color='primary' onClick={() => revertShipment()} autoFocus>
                            Revert
                        </Button>
                    </DialogActions>
                </Dialog>
            </div>
        </TransitionGroup>
    );
}

export default ShipmentCard;