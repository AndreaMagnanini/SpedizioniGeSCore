import React, {useState} from 'react';
import FerrariTheme from "../styles/FerrariTheme";
import {
    FormControl,
    FormControlLabel, IconButton,
    makeStyles, Radio,
    RadioGroup,
    ThemeProvider,
    Typography,
} from "@material-ui/core";
import {useWindowSize} from "../components/useLayoutWindows";
import ArrowBackIosIcon from '@mui/icons-material/ArrowBackIos';
import { useMediaQuery } from "@mui/material";
import theme from "../styles/FerrariTheme";
import {useNavigate} from "react-router-dom";
import { ShipmentType } from "../components/interfaces/ShipmentType";
import ShipmentDataForm from '../components/forms/ShipmentDataForm';

const useStyles = makeStyles({
    pageRoot: {
        display: "flex",
        flexDirection: "column",
        height:"100%",
        marginRight: "10px",
        marginLeft: "10px"
    },
    titleWrapper: {
        width: "100%",
        display: "flex",
        alignItems: "center",
        gap: "20px",
        paddingTop: "10px",
        paddingBottom: "10px",
        position: "fixed",
        backgroundColor: "#212121",
        zIndex: 2,
        boxShadow: "0px 8px 8px #21212180"
    },
    title: {
        textAlign: "left",
        color: "#D41217",
    },
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
    }
});

interface CreateShipmentProps{
    year: number;
}

const CreateShipment: React.FC<CreateShipmentProps> = ({year}) =>{
    const navigate = useNavigate();
    const classes = useStyles();
    const isMatch = useMediaQuery(theme.breakpoints.down('lg'))

    const config = isMatch ? {height: "100%", display:"flex", marginTop: "25px", marginBottom:"30px", }
        : {height: "100%", display:"flex", marginTop: "25px", marginBottom:"30px",};

    const [shipmentType, setShipmentType] = useState<ShipmentType>('air');
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

    return (
        <ThemeProvider theme={FerrariTheme}>
        <div className={classes.pageRoot}>
            <div className={classes.titleWrapper}>
                <IconButton onClick={() => navigate('/')} style={{ marginRight: "-10px"}}>
                    <ArrowBackIosIcon fontSize="large" style={{color: "#D41217", marginRight: "-20px"}}/>
                </IconButton>
                <Typography variant="h4" className={classes.title}>
                    New Shipment
                </Typography>
                <FormControl>
                    <RadioGroup row className={classes.typeSelect} defaultValue="air" onChange={(

                    event, value: ShipmentType)=> setShipmentType(value)}>
                        <FormControlLabel control={<Radio color="primary"/>} value="air" label={<Typography style={{color: "#eeeeee"}} 

                        variant='h6'>Air</Typography>}/>
                        <FormControlLabel control={<Radio color="primary"/>} value="ship" label={<Typography style={{color: "#eeeeee"}} 

                        variant="h6">Ship</Typography>}/>
                        <FormControlLabel control={<Radio color="primary"/>} value="ground" label={<Typography style={{color: "#eeeeee"}} 

                        variant="h6">Ground</Typography>}/>
                    </RadioGroup>
                </FormControl>
            </div>
            <div className={classes.mainContainer}>
                <ShipmentDataForm year={year} shipmentType={shipmentType}/>
                <div style={{ width: "100%", display: "flex" , paddingTop: "50px", flexDirection: "column", margin: "10px"}}>
                    <div className={classes.mainDiv} style={config}>
                        <Typography>New Shipment</Typography>
                    </div>
                </div>
            </div>
        </div>
    </ThemeProvider>
    );
}

export default CreateShipment;