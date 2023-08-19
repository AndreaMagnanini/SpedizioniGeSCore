// @ts-nocheck
import ShipmentCard from "../components/ShipmentCard";
import {Button, makeStyles, Tooltip, Typography, useTheme} from "@material-ui/core";
import AddIcon from '@material-ui/icons/Add';
import {useFetchShipments} from "./useFetchShipments";
import CircularProgress from "../components/CircularProgress";
import {useMediaQuery} from "@mui/material";
import {useLocation, useNavigate} from "react-router-dom";

const useStyles = makeStyles({
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
    pageRoot: {
        display: "flex",
        flexDirection: "column",
        height:"100%",
        marginRight: "10px",
        marginLeft: "10px"
    },
    newShipmentButton:{
        background: "linear-gradient(90deg, rgba(231,14,14,1) 0%, rgba(165,22,22,1) 66%)",
        marginTop: "8px",
        fontSize: "medium",
        '&:hover': {
            boxShadow: "5px 5px 25px rgba(0, 0, 0, 0.35)",
            transform: "scale3d(1.05, 1.05, 1)",
        }
    },
});
function Home({year}) {
    const navigate = useNavigate();
    const [shipments, isLoading] = useFetchShipments(year);
    const theme = useTheme();
    const classes = useStyles();
    const isMatch = useMediaQuery(theme.breakpoints.down('lg'))

    // Subset of props, to illustrate the idea.
    const config = isMatch ? {height: "100%", display:"flex", marginTop: "25px", marginBottom:"30px", marginRight: "16px", marginLeft: "16px"}
        : {height: "100%", display:"flex", marginTop: "25px", marginBottom:"30px", marginRight: "20px", marginLeft: "20px"};
    return (
        <div className={classes.pageRoot}>
            <div className={classes.titleWrapper}>
                <Typography variant="h4" className={classes.title}>
                    Shipments
                </Typography>
                {isLoading? <CircularProgress className={classes.loader}></CircularProgress> :
                    <Tooltip title="new shipment">
                        <Button
                            className={classes.newShipmentButton}
                            aria-label="new shipment"
                            variant="contained"
                            startIcon={<AddIcon fontSize="large"/>}
                            onClick={() => navigate('/shipment')}>
                            new
                        </Button>
                    </Tooltip>}
            </div>
            <div style={{ width: "100%", overflow: "auto", display: "flex" , paddingTop: "62px"}}>
                {shipments.map((shipment) => (
                    <div style={config}>
                        <ShipmentCard shipment={shipment}></ShipmentCard>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default Home;