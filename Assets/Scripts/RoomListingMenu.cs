using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    public RoomList _roomListPrefab;
    private List<RoomList> _listings = new List<RoomList>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        gameObject.SetActive(false);
        for (int i = _listings.Count-1; i>-1; i--)
        {
            Destroy(_listings[i].gameObject);
            _listings.RemoveAt(i);
        }
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomLists)
    {
        Debug.Log("OnRoomListUpdate" + roomLists.Count);
        base.OnRoomListUpdate(roomLists);
        foreach (RoomInfo info in roomLists)
        {

            int index = _listings.FindIndex(x => x.roomInf.Name == info.Name);
            Debug.Log("OnRoomListUpdate"+ info.Name);
            if (info.RemovedFromList)
            {
                if (index != 1)
                {
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                }
            }
            else
            {
                if (index != 1)
                {
                    RoomList roomList = Instantiate(_roomListPrefab);
                    if (roomList != null)
                    {
                        Debug.Log(roomList);
                        _listings.Add(roomList);
                        roomList.transform.parent = transform;
                        roomList.transform.localPosition = new Vector3(91.5f, 130 - 30 * roomList.transform.GetSiblingIndex()  -150, 0);
                        roomList.SetRoomInfo(info);
                    }
                }
            }
        }
    }
}
