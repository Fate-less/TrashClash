using UnityEngine;

namespace CardHouse
{
    public class TrashCard : CardSetup
    {
        public SpriteRenderer Image;
        public SpriteRenderer BackImage;
        public TrashType Kategori { get; private set; }
        public int Cost { get; private set; }
        public int Value { get; private set; }
        public int Penalty { get; private set; }
        public int None { get; private set; }
        public int Buff { get; private set; }
        public string Description { get; private set; }
        public bool affectAllyArea { get; private set; }
        public int affectAllyAmount { get; private set; }
        public ActiveCondition affectAllyCondition { get; private set; }
        public bool affectEnemyArea { get; private set; }
        public int affectEnemyAmount { get; private set; }
        public ActiveCondition affectEnemyCondition { get; private set; }

        public override void Apply(CardDefinition data)
        {
            if (data is CardSO trashCard)
            {
                Image.sprite = trashCard.Art;
                if (trashCard.BackArt != null)
                {
                    BackImage.sprite = trashCard.BackArt;
                }
                Cost = trashCard.Cost;
                Value = trashCard.Value;
                Penalty = trashCard.Penalty;
                Kategori = trashCard.Kategori;
                None = trashCard.None;
                Buff = trashCard.Buff;
                Description = trashCard.Description;
                affectAllyArea = trashCard.affectAllyArea;
                affectAllyAmount = trashCard.affectAllyAmount;
                affectEnemyArea = trashCard.affectEnemyArea;
                affectEnemyAmount = trashCard.affectEnemyAmount;
            }
        }
    }
}
